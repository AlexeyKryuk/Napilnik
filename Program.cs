using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using System.Reflection;

namespace Napilnik
{
    enum SearchResult
    {
        IS_PROVIDED,
        NOT_PROVIDED,
        NOT_FOUND,
    }

    class CleanCode_ExampleTask
    {
        private readonly string _сonnectionString = string.Format("Data Source=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\db.sqlite");
        
        private void OnButtonClick(object sender, EventArgs e)
        {
            string passportData = FormatPassportData(passportTextbox.Text);
            SqliteConnection connection = new SqliteConnection(_сonnectionString);
             
            if (ValidatePassportData(passportData))
            {
                if (ConnectToDatabase(connection))
                {
                    FindInDatabase(passportData, connection);

                    connection.Close();
                }
            }
        }

        private void FindInDatabase(string passportData, SqliteConnection connection)
        {
            string commandText = CreateCommandText(passportData);
            DataTable dataTable = CreateDataTable(commandText, connection);

            SearchResult searchResult = FindInDatatable(dataTable);
            DisplaySearchResult(searchResult, passportData);
        }

        private DataTable CreateDataTable(string commandText, SqliteConnection connection)
        {
            SQLiteDataAdapter sqLiteDataAdapter = new SQLiteDataAdapter(new SqliteCommand(commandText, connection));

            DataTable dataTable = new DataTable();
            sqLiteDataAdapter.Fill(dataTable);

            return dataTable;
        }

        private bool ConnectToDatabase(SqliteConnection connection)
        {
            try
            {
                connection.Open();

                return true;
            }
            catch (SqliteException ex)
            {
                MessageBox.Show("Файл db.sqlite не найден. Положите файл в папку вместе с exe.");

                return false;
            }
        }

        private SearchResult FindInDatatable(DataTable dataTable)
        {
            if (dataTable.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dataTable.Rows[0].ItemArray[1]))
                    return SearchResult.IS_PROVIDED;
                else
                    return SearchResult.NOT_PROVIDED;
            }
            else
                return SearchResult.NOT_FOUND;
        }

        private void DisplaySearchResult(SearchResult result, string passportData)
        {
            switch (result)
            {
                case SearchResult.IS_PROVIDED:
                    textResult.Text = "По паспорту «" + passportData + "» доступ к бюллетеню на дистанционном электронном голосовании ПРЕДОСТАВЛЕН";
                    break;
                case SearchResult.NOT_PROVIDED:
                    textResult.Text = "По паспорту «" + passportData + "» доступ к бюллетеню на дистанционном электронном голосовании НЕ ПРЕДОСТАВЛЯЛСЯ";
                    break;
                case SearchResult.NOT_FOUND:
                    textResult.Text = "Паспорт «" + passportData + "» в списке участников дистанционного голосования НЕ НАЙДЕН";
                    break;
                default:
                    break;
            }
        }

        private bool ValidatePassportData(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                MessageBox.Show("Введите серию и номер паспорта");
                return false;
            }

            if (data.Length < 10)
            {
                textResult.Text = "Неверный формат серии или номера паспорта";
                return false;
            }

            return true;
        }

        private string CreateCommandText(string passportData)
        {
            return string.Format("select * from passports where num='{0}' limit 1;", Form1.ComputeSha256Hash(passportData));
        }

        private string FormatPassportData(string data)
        {
            return data.Trim().Replace(" ", string.Empty);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
