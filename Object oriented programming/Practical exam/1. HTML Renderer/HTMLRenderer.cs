using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace HTMLRenderer
{
	public interface IElement
	{
		string Name { get; }
		string TextContent { get; set; }
		IEnumerable<IElement> ChildElements { get; }
		void AddElement(IElement element);
		void Render(StringBuilder output);
		string ToString();
	}

	public interface ITable : IElement
	{
		int Rows { get; }
		int Cols { get; }
		IElement this[int row, int col] { get; set; }
	}

	public class Element : IElement 
	{
		private List<IElement> childElements;

		public Element(string name) 
			: this(name, null)
		{
		}

		public Element(string name, string textContent)
		{
			Name = name;
			TextContent = textContent;
			childElements = new List<IElement>();
		}

		public string Name { get; protected set; }

		public string TextContent { get; set; }

		public void AddElement(IElement element)
		{
			childElements.Add(element);
		}

		public IEnumerable<IElement> ChildElements
		{
			get
			{
				return childElements;
			}
		}

		public void Render(StringBuilder output)
		{
			output.Append(this.ToString() + Environment.NewLine);
		}

		public override string ToString()
		{
			var result = new StringBuilder();

			if (this.Name == null) 
			{
				return this.TextContent != null ? this.TextContent : string.Empty;
			}

			result.Append(string.Format("<{0}>", this.Name));

			//Get escaped content
			var content = new StringBuilder();
			if (this.TextContent != null)
			{
				foreach (char item in this.TextContent)
				{
					if (item == '<')
					{
						content.Append("&lt;");
					}
					else if (item == '>')
					{
						content.Append("&gt;");
					}
					else if (item == '&')
					{
						content.Append("&amp;");
					}
					else
					{
						content.Append(item);
					}
				}
			}

			result.Append(content.ToString());

			//Get childs
			foreach (IElement child in this.ChildElements)
			{
				result.Append(child.ToString());
			}

			result.Append(string.Format("</{0}>", this.Name));

			return result.ToString();
		}
	}

	public class Table : ITable
	{
		private const string TableName = "table";

		private IElement[,] childElements;

		private int rows;
		private int cols;

		// Constructor
		public Table(int rows, int cols) 
		{
			this.Rows = rows;
			this.Cols = cols;

			childElements = new IElement[rows, cols];
		}

		public string Name 
		{
			get { return TableName; }
		}

		public string TextContent 
		{
			get 
			{
				return null;
			}
			set 
			{ 
				throw new InvalidOperationException(); 
			} 
		}

		public IEnumerable<IElement> ChildElements
		{
			get
			{
				return null;
			}
		}

		public void AddElement(IElement element)
		{
			throw new InvalidOperationException();
		}

		public int Rows
		{
			get 
			{
				return this.rows;
			}
			protected set 
			{
				if (value < 0) 
				{
					throw new ArgumentOutOfRangeException("Rows", "Invalid negative value.");
				}

				this.rows = value;
			}
		}

		public int Cols
		{
			get
			{
				return this.cols;
			}
			protected set 
			{
				if (value < 0) 
				{
					throw new ArgumentOutOfRangeException("Cols", "Invalid negative value.");
				}

				this.cols = value;
			}
		}

		public IElement this[int row, int col]
		{
			get
			{
				return childElements[row, col];
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException();
				}

				childElements[row, col] = value;
			}
		}

		public void Render(StringBuilder output)
		{
			output.Append(this.ToString() + Environment.NewLine);
		}

		public override string ToString()
		{
			var result = new StringBuilder();

			result.Append(string.Format("<{0}>", this.Name));

			//Get childs
			for (int i = 0; i < this.Rows; i++)
			{
				result.Append("<tr>");
				for (int j = 0; j < this.Cols; j++)
				{
					result.Append("<td>");
					result.Append(childElements[i,j].ToString());
					result.Append("</td>");
				}
				result.Append("</tr>");
			}

			result.Append(string.Format("</{0}>", this.Name));

			return result.ToString();
		}
	}

    public interface IElementFactory
    {
		IElement CreateElement(string name);
		IElement CreateElement(string name, string content);
		ITable CreateTable(int rows, int cols);
    }

    public class HTMLElementFactory : IElementFactory
    {
		public IElement CreateElement(string name)
		{
			var element = new Element(name);
			return element;
		}

		public IElement CreateElement(string name, string content)
		{
			var element = new Element(name, content);
			return element;
		}

		public ITable CreateTable(int rows, int cols)
		{
			var table = new Table(rows, cols);
			return table;
		}
	}

    public class HTMLRendererCommandExecutor
    {
        static void Main()
        {
			string csharpCode = ReadInputCSharpCode();
			CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using HTMLRenderer;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}
