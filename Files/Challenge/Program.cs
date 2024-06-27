
//Christos Ebeatu BU/22c/IT/7789

const string dirname = "FileCollection";
const string filename = "results.txt";

bool IsOfficeFile(string filename)
{
    string fileExtension = Path.GetExtension(filename);

    if (fileExtension == ".xlsx" || fileExtension == ".docx" || fileExtension == ".pptx")
    {
        return true;
    }
    return false;
}

int pptxCount = 0, xlsxCount = 0, docxCount = 0, totalCount = 0;
long pptxSize = 0, xlsxSize = 0, docxSize = 0, totalSize = 0;

DirectoryInfo dirInfo = new(dirname);

List<string> directories = new(Directory.EnumerateFiles(dirname));
foreach (string file in directories)
{
    Console.WriteLine(file);
    if (IsOfficeFile(file))
    {
        FileInfo fileInfo = new(file);

        if (fileInfo.Extension == ".xlsx")
        {
            xlsxCount++;
            xlsxSize += fileInfo.Length;
        }
        if (fileInfo.Extension == ".pptx")
        {
            pptxCount++;
            pptxSize += fileInfo.Length;
        }
        if (fileInfo.Extension == ".docx")
        {
            docxCount++;
            docxSize += fileInfo.Length;
        }
    }
}

totalSize = pptxSize + xlsxSize + docxSize;
totalCount = pptxCount + xlsxCount + docxCount;


using StreamWriter sw = File.CreateText(filename);
sw.WriteLine($"Word File Count: {docxCount}");
sw.WriteLine($"Excel File Count: {xlsxCount}");
sw.WriteLine($"Powerpoint File Count: {pptxCount}");
sw.WriteLine($"Word File Size: {docxSize}");
sw.WriteLine($"Excel File Size: {xlsxSize}");
sw.WriteLine($"Powerpoint File Size: {pptxSize}");
sw.WriteLine($"Total Count: {totalCount}");
sw.WriteLine($"Total Size: {totalSize}");


sw.Close();




