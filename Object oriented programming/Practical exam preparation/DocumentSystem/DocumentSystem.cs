using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IDocument
{
	string Name { get; }
	
	string Content { get; }

	void LoadProperty(string key, string value);

	void SaveAllProperties(IList<KeyValuePair<string, object>> output);

	string ToString();
}

public interface IEditable
{
	void ChangeContent(string newContent);
}

public interface IEncryptable
{
	bool IsEncrypted { get; }

	void Encrypt();

	void Decrypt();
}

public class Document : IDocument
{
	public string Name { get; protected set; }

	public string Content { get; protected set; }

	public virtual void LoadProperty(string key, string value)
	{
		if (key == "name")
		{
			this.Name = value;
		}
		else if (key == "content")
		{
			this.Content = value;
		}
		else
		{
			throw new Exception("Not valid property name");
		}
	}

	public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
	{
		output.Add(new KeyValuePair<string, object>("name", this.Name));
		output.Add(new KeyValuePair<string, object>("content", this.Content));
	}

	public override string ToString()
	{
		var result = new StringBuilder();
		result.Append(this.GetType().Name);

		var properties = new List<KeyValuePair<string, object>>();
		this.SaveAllProperties(properties);

		result.Append("[");
		foreach (var property in properties)
		{
			result.Append(property.Key);
			result.Append("=");
			result.Append(property.Value);
			result.Append(";");
		}

		//Removes last ';'
		result = result.Remove(result.Length - 1, 1);

		result.Append("]");

		return result.ToString();
	}
}

public class TextDocument : Document, IEditable 
{
	public string Charset { get; protected set; }

	public override void LoadProperty(string key, string value)
	{
		if (key == "charset")
		{
			this.Charset = value;
		}
		else
		{
			base.LoadProperty(key, value);
		}
	}

	public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
	{
		output.Add(new KeyValuePair<string, object>("charset", this.Charset));
		base.SaveAllProperties(output);
	}

	public void ChangeContent(string newContent)
	{
		this.Content = newContent;
	}
}

public abstract class BinaryDocument : Document
{
	public long? Size { get; set; }

	public override void LoadProperty(string key, string value)
	{
		if (key == "size")
		{
			this.Size = long.Parse(value);
		}
		else
		{
			base.LoadProperty(key, value);
		}
	}

	public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
	{
		output.Add(new KeyValuePair<string, object>("size", this.Size));
		base.SaveAllProperties(output);
	}
}

public abstract class EncryptableBinaryDocument : BinaryDocument, IEncryptable
{
	private bool isEncrypted = false;

	public bool IsEncrypted
	{
		get
		{
			return this.isEncrypted;
		}
	}

	public void Encrypt()
	{
		this.isEncrypted = true;
	}

	public void Decrypt()
	{
		this.isEncrypted = false;
	}

	public override string ToString()
	{
		if (this.isEncrypted)
		{
			return this.GetType().Name + "[encrypted]";
		}
		else
		{
			return base.ToString();
		}
	}
}

public abstract class OfficeDocument : EncryptableBinaryDocument
{
	public string Version { get; set; }

	public override void LoadProperty(string key, string value)
	{
		if (key == "version")
		{
			this.Version = value;
		}
		else
		{
			base.LoadProperty(key, value);
		}
	}

	public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
	{
		output.Add(new KeyValuePair<string, object>("version", this.Version));
		base.SaveAllProperties(output);
	}
}

public class WordDocument : OfficeDocument, IEditable
{
	public int? CharsCount { get; set; }

	public override void LoadProperty(string key, string value)
	{
		if (key == "chars")
		{
			this.CharsCount = int.Parse(value);
		}
		else
		{
			base.LoadProperty(key, value);
		}
	}

	public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
	{
		output.Add(new KeyValuePair<string, object>("chars", this.CharsCount));
		base.SaveAllProperties(output);
	}

	public void ChangeContent(string newContent)
	{
		this.Content = newContent;
	}
}

public class ExcelDocument : OfficeDocument
{
	public int? Rows { get; protected set; }

	public int? Columns { get; protected set; }

	public override void LoadProperty(string key, string value)
	{
		if (key == "rows")
		{
			this.Rows = int.Parse(value);
		}
		else if (key == "cols")
		{
			this.Columns = int.Parse(value);
		}
		else
		{
			base.LoadProperty(key, value);
		}
	}

	public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
	{
		output.Add(new KeyValuePair<string, object>("rows", this.Rows));
		output.Add(new KeyValuePair<string, object>("cols", this.Columns));
		base.SaveAllProperties(output);
	}
}

public class PDFDocument : EncryptableBinaryDocument
{
	public int? PagesCount { get; set; }

	public override void LoadProperty(string key, string value)
	{
		if (key == "pages")
		{
			this.PagesCount = int.Parse(value);
		}
		else
		{
			base.LoadProperty(key, value);
		}
	}

	public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
	{
		output.Add(new KeyValuePair<string, object>("pages", this.PagesCount));
		base.SaveAllProperties(output);
	}
}

public abstract class MultimediaDocument : BinaryDocument
{
	public int? Length { get; set; }

	public override void LoadProperty(string key, string value)
	{
		if (key == "length")
		{
			this.Length = int.Parse(value);
		}
		else
		{
			base.LoadProperty(key, value);
		}
	}

	public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
	{
		output.Add(new KeyValuePair<string, object>("length", this.Length));
		base.SaveAllProperties(output);
	}
}

public class AudioDocument : MultimediaDocument
{
	public int? SampleRate { get; set; }

	public override void LoadProperty(string key, string value)
	{
		if (key == "samplerate")
		{
			this.SampleRate = int.Parse(value);
		}
		else
		{
			base.LoadProperty(key, value);
		}
	}

	public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
	{
		output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
		base.SaveAllProperties(output);
	}
}

public class VideoDocument : MultimediaDocument
{
	public int? Framerate { get; set; }

	public override void LoadProperty(string key, string value)
	{
		if (key == "framerate")
		{
			this.Framerate = int.Parse(value);
		}
		else
		{
			base.LoadProperty(key, value);
		}
	}

	public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
	{
		output.Add(new KeyValuePair<string, object>("framerate", this.Framerate));
		base.SaveAllProperties(output);
	}
}

public class DocumentSystem
{
	private static IList<IDocument> documents;

	static void Main()
	{
		documents = new List<IDocument>();

		IList<string> allCommands = ReadAllCommands();
		ExecuteCommands(allCommands);
	}

	private static IList<string> ReadAllCommands()
	{
		List<string> commands = new List<string>();
		while (true)
		{
			string commandLine = Console.ReadLine();
			if (commandLine == "")
			{
				// End of commands
				break;
			}
			commands.Add(commandLine);
		}
		return commands;
	}

	private static void ExecuteCommands(IList<string> commands)
	{
		foreach (var commandLine in commands)
		{
			int paramsStartIndex = commandLine.IndexOf("[");
			string cmd = commandLine.Substring(0, paramsStartIndex);
			int paramsEndIndex = commandLine.IndexOf("]");
			string parameters = commandLine.Substring(
				paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
			ExecuteCommand(cmd, parameters);
		}
	}

	private static void ExecuteCommand(string cmd, string parameters)
	{
		string[] cmdAttributes = parameters.Split(
			new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
		if (cmd == "AddTextDocument")
		{
			AddTextDocument(cmdAttributes);
		}
		else if (cmd == "AddPDFDocument")
		{
			AddPdfDocument(cmdAttributes);
		}
		else if (cmd == "AddWordDocument")
		{
			AddWordDocument(cmdAttributes);
		}
		else if (cmd == "AddExcelDocument")
		{
			AddExcelDocument(cmdAttributes);
		}
		else if (cmd == "AddAudioDocument")
		{
			AddAudioDocument(cmdAttributes);
		}
		else if (cmd == "AddVideoDocument")
		{
			AddVideoDocument(cmdAttributes);
		}
		else if (cmd == "ListDocuments")
		{
			ListDocuments();
		}
		else if (cmd == "EncryptDocument")
		{
			EncryptDocument(parameters);
		}
		else if (cmd == "DecryptDocument")
		{
			DecryptDocument(parameters);
		}
		else if (cmd == "EncryptAllDocuments")
		{
			EncryptAllDocuments();
		}
		else if (cmd == "ChangeContent")
		{
			ChangeContent(cmdAttributes[0], cmdAttributes[1]);
		}
		else
		{
			throw new InvalidOperationException("Invalid command: " + cmd);
		}
	}
  
	private static void AddTextDocument(string[] attributes)
	{
		AddDocument(new TextDocument(), attributes);
	}

	private static void AddPdfDocument(string[] attributes)
	{
		AddDocument(new PDFDocument(), attributes);		
	}

	private static void AddWordDocument(string[] attributes)
	{
		AddDocument(new WordDocument(), attributes);
	}

	private static void AddExcelDocument(string[] attributes)
	{
		AddDocument(new ExcelDocument(), attributes);
	}

	private static void AddAudioDocument(string[] attributes)
	{
		AddDocument(new AudioDocument(), attributes);
	}

	private static void AddVideoDocument(string[] attributes)
	{
		AddDocument(new VideoDocument(), attributes);
	}

	private static void AddDocument(IDocument document, string[] attributes) 
	{
		foreach (var attribute in attributes)
		{
			string[] attributeParts = attribute.Split('=');
			document.LoadProperty(attributeParts[0], attributeParts[1]);
		}

		if (string.IsNullOrEmpty(document.Name))
		{
			documents.Add(document);
			Console.WriteLine("Document added: " + document.Name);
		}
		else
		{
			Console.WriteLine("Document has no name");
		}
	}

	private static void ListDocuments()
	{
		if (!documents.Any()) 
		{
			Console.WriteLine("No documents found");
			return;
		}

		foreach (var document in documents)
		{
			Console.WriteLine(document.ToString());
		}
	}

	private static void EncryptDocument(string name)
	{
		if (!documents.Where(x => x.Name == name).Any())
		{
			Console.WriteLine("Document not found: " + name);
			return;
		}

		var currentNameDocuments = documents.Where(x => x.Name == name).ToArray();

		foreach (var document in currentNameDocuments)
		{
			if (document is IEncryptable)
			{
				((IEncryptable)document).Encrypt();
				Console.WriteLine("Document encrypted: " + name);
			}
			else
			{
				Console.WriteLine("Document does not support encryption: " + name);
			}
		}
	}

	private static void DecryptDocument(string name)
	{
		if (!documents.Where(x => x.Name == name).Any())
		{
			Console.WriteLine("Document not found: " + name);
			return;
		}

		var currentNameDocuments = documents.Where(x => x.Name == name).ToArray();

		foreach (var document in currentNameDocuments)
		{
			if (document is IEncryptable)
			{
				((IEncryptable)document).Decrypt();
				Console.WriteLine("Document decrypted: " + name);
			}
			else
			{
				Console.WriteLine("Document does not support decryption: " + name);
			}
		}
	}

	private static void EncryptAllDocuments()
	{
		if (!documents.Where(x => x is IEditable).Any()) 
		{
			Console.WriteLine("No encryptable documents found");
			return;
		}

		foreach (var doc in documents.Where(x => x is IEditable))
		{
			if (doc is IEncryptable)
			{
				((IEncryptable)doc).Encrypt();
			}
		}
            
		Console.WriteLine("All documents encrypted");
	}

	private static void ChangeContent(string name, string content)
	{
		if (!documents.Where(x => x is IEditable).Any())
		{
			Console.WriteLine("Document not found: " + name);
			return;
		}

		foreach (var doc in documents.Where(x => x.Name == name))
		{
			if (doc is IEditable)
			{
				((IEditable)doc).ChangeContent(content);
				Console.WriteLine("Document content changed: " + doc.Name);
			}
			else
			{
				Console.WriteLine("Document is not editable: " + doc.Name);
			}
		}
	}
}