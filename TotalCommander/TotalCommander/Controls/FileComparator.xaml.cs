using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace TotalCommander.Controls
{
    /// <summary>
    /// Interaction logic for FileComparator.xaml
    /// </summary>
    public partial class FileComparator : UserControl
    {
        public FileComparator()
        {
            InitializeComponent();
        }

        public FileComparator(in Model.MemoryItem firstFile, in Model.MemoryItem secondFile) : this()
        {
            if (Path.GetExtension(firstFile.Path) == ".txt" && Path.GetExtension(secondFile.Path) == ".txt")
            {
                Compare(firstFile, secondFile);
            }
        }
        public void Compare(in Model.MemoryItem firstFile, in Model.MemoryItem secondFile)
        {
            try
            {
                string firstContent = System.IO.File.ReadAllText(firstFile.Path);
                string secondContent = System.IO.File.ReadAllText(secondFile.Path);
                CharEnumerator first = firstContent.GetEnumerator();
                CharEnumerator second = secondContent.GetEnumerator();
                while (first.MoveNext() && second.MoveNext())
                {
                    Run leftChar = new Run(first.Current.ToString());
                    Run rightChar = new Run(second.Current.ToString());
                    if (first.Current != second.Current)
                    {
                        leftChar.Foreground = Brushes.Red;
                        rightChar.Foreground = Brushes.Red;
                    }
                    this.leftTextBlock.Inlines.Add(leftChar);
                    this.rightTextBlock.Inlines.Add(rightChar);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

        }
    }
}
