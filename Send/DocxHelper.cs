
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;

namespace Producer
{
    public class DocxHelper
    {
        public static void ReadTablesFromWordDocument(string fileName)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(fileName, false))
            {
                MainDocumentPart mainPart = wordDocument.MainDocumentPart;
                IEnumerable<Table> tables = mainPart.Document.Body.Elements<Table>();

                foreach (Table table in tables)
                {
                    Console.WriteLine("=====NEW TABLE======");
                    ReadTable(table);
                }
            }
        }

        static void ReadTable(Table table)
        {
            foreach (TableRow tableRow in table.Elements<TableRow>())
            {
                Console.WriteLine();
                ReadTableRow(tableRow);
            }
        }

        static void ReadTableRow(TableRow tableRow)
        {
            foreach (TableCell tableCell in tableRow.Elements<TableCell>())
            {
                ReadTableCell(tableCell);
            }
        }

        static void ReadTableCell(TableCell tableCell)
        {
            foreach (Paragraph paragraph in tableCell.Elements<Paragraph>())
            {
                Console.Write(paragraph.InnerText);
                Console.Write(" ");
            }
        }
    }
}