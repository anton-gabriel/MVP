using System;
using System.Collections.Generic;
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
        #region Constructors
        public FileComparator()
        {
            InitializeComponent();
        }
        public FileComparator(in Model.MemoryItem firstFile, in Model.MemoryItem secondFile) : this()
        {
            CurrentLine = 0;
            if (Path.GetExtension(firstFile.Path) == ".txt" && Path.GetExtension(secondFile.Path) == ".txt")
            {
                Compare(firstFile, secondFile);
            }
        }
        #endregion

        #region Properties
        public uint CurrentLine { get; private set; }
        #endregion

        #region Public methods
        public void Compare(in Model.MemoryItem firstFile, in Model.MemoryItem secondFile)
        {
            string[] firstContent = System.IO.File.ReadAllLines(firstFile.Path);
            string[] secondContent = System.IO.File.ReadAllLines(secondFile.Path);
            System.Collections.IEnumerator first = firstContent.GetEnumerator();
            System.Collections.IEnumerator second = secondContent.GetEnumerator();
            while (first.MoveNext() && second.MoveNext())
            {
                CompareLines((first.Current as string).Trim(), (second.Current as string).Trim());
            }
            CompleteLines(this.leftTextBlock, first);
            CompleteLines(this.rightTextBlock, second);
        }
        #endregion

        #region Private methods
        private void CompareLines(in string firstLine, in string secondLine)
        {
            try
            {
                bool identical = true;
                CharEnumerator first = firstLine.GetEnumerator();
                CharEnumerator second = secondLine.GetEnumerator();
                List<Run> leftLine = new List<Run>();
                List<Run> rightLine = new List<Run>();
                while (first.MoveNext() && second.MoveNext())
                {
                    Run leftChar = new Run(first.Current.ToString());
                    Run rightChar = new Run(second.Current.ToString());
                    if (first.Current != second.Current)
                    {
                        leftChar.Foreground = Brushes.Red;
                        rightChar.Foreground = Brushes.Red;
                        identical = false;
                    }
                    leftLine.Add(leftChar);
                    rightLine.Add(rightChar);
                }
                if (identical)
                {
                    leftLine.ForEach(element => element.Foreground = Brushes.Green);
                    rightLine.ForEach(element => element.Foreground = Brushes.Green);
                }
                AddLine(leftLine, rightLine);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        private void AddLine(in List<Run> leftLine, in List<Run> rightLine)
        {
            ++CurrentLine;
            this.leftTextBlock.Inlines.Add(CurrentLine.ToString() + ". ");
            this.rightTextBlock.Inlines.Add(CurrentLine.ToString() + ". ");
            this.leftTextBlock.Inlines.AddRange(leftLine);
            this.rightTextBlock.Inlines.AddRange(rightLine);
            this.leftTextBlock.Inlines.Add(Environment.NewLine);
            this.rightTextBlock.Inlines.Add(Environment.NewLine);
        }
        private void CompleteLines(in TextBlock textBlock, System.Collections.IEnumerator enumerator)
        {
            while (enumerator.MoveNext())
            {
                ++CurrentLine;
                textBlock.Inlines.Add(CurrentLine.ToString() + ". ");
                textBlock.Inlines.Add((enumerator.Current as string).Trim());
                textBlock.Inlines.Add(Environment.NewLine);
            }
        }
        #endregion
    }
}
