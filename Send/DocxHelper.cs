
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using CurriculumProducer.DTOs;
namespace CurriculumProducer
{
    public class DocxHelper
    {
        public static List<CourseDTO> ReadTablesFromWordDocument(string fileName)
        {   
            var courses = new List<CourseDTO>();
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(fileName, false))
            {
                MainDocumentPart mainPart = wordDocument.MainDocumentPart;
                IEnumerable<Table> tables = mainPart.Document.Body.Elements<Table>();

                foreach (Table table in tables)
                {
                    ReadTable(table);
                }
            }
            return courses;
        }

        static void ReadTable(Table table)
        {
            foreach (TableRow tableRow in table.Elements<TableRow>())
            {
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