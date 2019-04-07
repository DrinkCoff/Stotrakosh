﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace Stotrakosh
{
    public static class DatabaseOp
    {
        public static ObservableCollection<Stotra> GetStotrasFromDb()
        {
            ObservableCollection<Stotra> stotras = new ObservableCollection<Stotra>();

            string databaseFilePath = GetDatabasePath();

            DatabaseFileCheck(databaseFilePath);

            if (File.Exists(path: databaseFilePath))
            {
                var db = new SQLiteConnection(databaseFilePath);
                db.CreateTable<StotraInDb>();

                string query = @"select * from Stotras";

                var values = db.Query<StotraInDb>(query);

                if (values.Count > 0)
                {
                    foreach (StotraInDb stotraInDb in values)
                    {
                        stotras.Add(new Stotra(stotraInDb.Name, stotraInDb.Content, Convert.ToBoolean(stotraInDb.IsFavorite)));
                    }
                }
            }

            return stotras;
        }

        public static string GetDatabasePath()
        {
            string currentLanguage = Settings.Language;

            string databaseName = "stotra-Sanskrit.db3";

            switch (currentLanguage)
            {
                case "संस्कृत (Sanskrit)":
                    databaseName = "stotra-Sanskrit.db3";
                    break;
                case "ગુજરાતી (Gujarati)":
                    databaseName = "stotra-Gujarati.db3";
                    break;
                case "English":
                    databaseName = "stotra-English.db3";
                    break;
                default:
                    break;
            }
            
            string directory = Settings.DatabaseDirectory;

            string databasePath = Path.Combine(directory, databaseName);

            return databasePath;
        }

        public static void UpdateIsFavorite(string stotraName)
        {
            string databasePath = GetDatabasePath();

            if (DatabaseFileCheck(databasePath))
            {
                var db = new SQLiteConnection(databasePath);
                db.CreateTable<StotraInDb>();

                var values = db.Query<StotraInDb>(@"select * from Stotras where name = '" + stotraName + "'");

                if (values.Count == 1)
                {
                    int isFavoriteVal = values[0].IsFavorite;
                    isFavoriteVal = (isFavoriteVal == 1) ? 0 : 1;

                    values = db.Query<StotraInDb>(@"update Stotras set IsFavorite = " + isFavoriteVal.ToString() + " where name = '" + stotraName + "'");

                    if (values.Count == 1)
                    {

                    }
                }
            }
        }

        public static bool DatabaseFileCheck(string databaseFilePath)
        {
            if(!File.Exists(databaseFilePath))
            {
                return false;
            }
            return true;
        }

    }
}
