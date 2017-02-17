using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.awt;
using iTextSharp.testutils;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.xmp;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ResumeCreator
{
    class Constructor
    {
        private string image_path;
        private string full_name;
        private string date;
        private string nationality;
        private string address;
        private string hphone;
        private string mphone;
        private string email;
        private string target;
        private string salary;
        private string schedule;
        private string employment;
        private string[] skills;
        private string[] institution;
        private string language;
        private string[] experience;
        private string[] duties;
        private string[] achievements;
        private string additionally;
        public Constructor(string image_path,
            string surname, string name, string patronymic,
            string num, string month, string year,
            string nationality,
            string city, string address,
            string hphone,
            string mphone,
            string email,
            string target,
            string salary,
            string schedule,
            string employment,
            string skills,
            string institution, string learn_month, string learn_year, string specialty, string education,
            string language, string level,
            string company, string description, string position, string begin_month, string begin_year,
                                                string end_month, string end_year, bool? present,
            string duties, 
            string achievements,
            string additionally)
        {
            string full = "";
            //Путь к фотографии
            if (image_path != "")
                this.image_path = image_path;
            //Полное имя
            if (surname != "") full += surname + " ";
            full += name;
            if (patronymic != "") full += " " + patronymic;
            full_name = full;
            //Дата рождения
            full = "";
            if (num != "")
                full += num + " ";
            if (month != "")
                full += month;
            if (year != "")
                full += " " + year;
            if (full != "")
                date = full;
            //Гражданство
            if (nationality != "")
                this.nationality = nationality;
            //Место жительства
            full = "";
            full += city;
            if (address != "")
                full += ", " + address;
            this.address = full;
            //Домашний телефон
            if (hphone != "")
                this.hphone = hphone;
            //Мобильный телефон
            this.mphone = mphone;
            //Электронная почта
            if (email != "")
                this.email = email;
            //Цель
            this.target = target;
            //Желаемая зарплата
            if (salary != "")
                this.salary = salary;
            //График работы
            if (schedule != "")
                this.schedule = schedule;
            //Занятость
            if (employment != "")
                this.employment = employment;
            //Профессиональные навыки
            this.skills = skills.Split('\n');
            //Образование
            this.institution = String.Format($"{institution}\n ({learn_month} {learn_year} г.)\n{specialty} ({education})").Split('\n');
            //Язык
            full = "";
            if(language != "")
            {
                full += language;
                if (level != "")
                    full += $" ({level})";
            }
            if (full != "")
                this.language = full;
            //Опыт работы
            full = "";
            full += company;
            if (description != "")
                full += "\n" + $"({description})";
            full += "\n" + position + $" ({begin_month} {begin_year} г. - ";
            if (present == true)
                full += "н.в)";
            else full += $"{end_month} {end_year} г.)";
            this.experience = full.Split('\n');
            //Обязанности
            this.duties = duties.Split('\n');
            //Достижения
            if (achievements != "")
                this.achievements = achievements.Split('\n');
            //Доп. сведения
            if (additionally != "")
                this.additionally = additionally;
        }
        public void CreateFile()
        {
            Font title_font = new Font(BaseFont.CreateFont(Application.StartupPath + @"\Fonts\arialbi.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED), 14, Font.NORMAL);
            Font normal_font = new Font(BaseFont.CreateFont(Application.StartupPath + @"\Fonts\ariali.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED), 10, Font.NORMAL);
            Font hight_font = new Font(BaseFont.CreateFont(Application.StartupPath + @"\Fonts\arialbi.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED), 10, Font.NORMAL);
            Document doc = new Document(PageSize.A4, 0, 0, 20, 0);
            PdfWriter.GetInstance(doc, new FileStream(Application.StartupPath + @"\Resume.pdf", FileMode.OpenOrCreate));
            doc.Open();
            PdfPTable table = new PdfPTable(2);
            table.SpacingBefore = 0;
            table.SpacingAfter = 0;
            float[] w = { 4, 1 };
            table.DefaultCell.Border = PdfPCell.NO_BORDER;
            table.SetWidths(w);
            PdfPTable block = new PdfPTable(2);
            block.DefaultCell.Border = PdfPCell.NO_BORDER;
            PdfPCell cell = new PdfPCell(new Phrase(full_name + "\n", title_font));
            cell.Padding = 10;
            cell.Colspan = 2;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = PdfPCell.NO_BORDER;
            block.AddCell(cell);
            if(date != null)
            {
                block.AddCell(new Phrase("Дата рождения:", hight_font));
                block.AddCell(new Phrase(date, normal_font));
            }
            if(nationality != null)
            {
                block.AddCell(new Phrase("Гражданство:", hight_font));
                block.AddCell(new Phrase(nationality, normal_font));
            }
            if (date != null)
            {
                block.AddCell(new Phrase("Дата рождения:", hight_font));
                block.AddCell(new Phrase(date, normal_font));
            }
            if (address != null)
            {
                block.AddCell(new Phrase("Место жительства:", hight_font));
                block.AddCell(new Phrase(address, normal_font));
            }
            if (hphone != null)
            {
                block.AddCell(new Phrase("Домашний телефон:", hight_font));
                block.AddCell(new Phrase(hphone, normal_font));
            }
            if (mphone != null)
            {
                block.AddCell(new Phrase("Мобильный телефон:", hight_font));
                block.AddCell(new Phrase(mphone, normal_font));
            }
            if (email != null)
            {
                block.AddCell(new Phrase("E-Mail:", hight_font));
                block.AddCell(new Phrase(email, normal_font));
            }
            table.AddCell(block);
            Image image = Image.GetInstance(image_path);
            table.AddCell(image);
            doc.Add(table);
            table = new PdfPTable(2);
            table.SpacingBefore = 0;
            table.SpacingAfter = 0;
            w[0] = 2.7f; w[1] = 4;
            table.DefaultCell.Border = PdfPCell.NO_BORDER;
            table.SetWidths(w);
            table.AddCell(new Phrase("Цель:", hight_font));
            cell = new PdfPCell();
            cell.Border = PdfPCell.NO_BORDER;
            cell.AddElement(new Phrase(target, normal_font));
            if(salary == null)
            {
                cell.AddElement(Chunk.NEWLINE);
                table.AddCell(cell);
            }
            else
            {
                table.AddCell(cell);
                table.AddCell(new Phrase("Желаемая зарплата:", hight_font));
                cell = new PdfPCell();
                cell.AddElement(new Phrase(salary, normal_font));
                cell.AddElement(Chunk.NEWLINE);
                table.AddCell(cell);
            }
            if (schedule != null)
            {
                table.AddCell(new Phrase("График работы:", hight_font));
                table.AddCell(new Phrase(schedule, normal_font));
            }
            if(employment != null)
            {
                table.AddCell(new Phrase("Занятость", hight_font));
                table.AddCell(new Phrase(employment, normal_font));
            }


            table.AddCell(" ");
            table.AddCell(" ");
            table.AddCell(new Phrase("Проф. навыки:", hight_font));
            table.AddCell(new Phrase(skills[0], normal_font));
            for(int i = 1; i < skills.Length; i++)
            {
                table.AddCell(" ");
                table.AddCell(new Phrase(skills[i], normal_font));
            }

            table.AddCell(" ");
            table.AddCell(" ");
            table.AddCell(new Phrase("Образование:", hight_font));
            cell = new PdfPCell();
            cell.Border = PdfPCell.NO_BORDER;
            Phrase phrase = new Phrase(institution[0], hight_font);
            phrase.Add(new Phrase(institution[1], normal_font));
            cell.AddElement(phrase);
            cell.AddElement(new Phrase(institution[1], normal_font));
            table.AddCell(cell);

            table.AddCell(" ");
            table.AddCell(" ");
            table.AddCell(new Phrase("Опыт работы:", hight_font));
            cell = new PdfPCell();
            cell.Border = PdfPCell.NO_BORDER;
            cell.AddElement(new Phrase(experience[0], hight_font));
            for(int i = 1; i < experience.Length; i++)
            {
                cell.AddElement(new Phrase(experience[i], normal_font));
            }
            cell.AddElement(Chunk.NEWLINE);
            cell.AddElement(new Phrase("Обязанности:", hight_font));
            cell.AddElement(Chunk.NEWLINE);
            foreach(string d in duties)
            {
                cell.AddElement(new Phrase(d, normal_font));
            }
            if(achievements != null)
            {
                cell.AddElement(Chunk.NEWLINE);
                cell.AddElement(new Phrase("Достижения:", hight_font));
                cell.AddElement(Chunk.NEWLINE);
                foreach(string a in achievements)
                {
                    cell.AddElement(new Phrase(a, normal_font));
                }
            }
            cell.AddElement(Chunk.NEWLINE);
            table.AddCell(cell);
            if (additionally != null)
            {
                table.AddCell(new Phrase("Доп. сведения", hight_font));
                table.AddCell(new Phrase(additionally, normal_font));
            }
            doc.Add(table);
            doc.Close();
        }
    }
}
