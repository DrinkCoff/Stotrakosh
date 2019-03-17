using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stotrakosh
{
    public class Stotra
    {
        private string name;
        private string lyrics;

        public string Name { get { return name; } }
        public string Lyrics { get { return lyrics; } }
        
        public Stotra(string name, string lyrics)
        {
            this.name = name;
            this.lyrics = lyrics;
        }
    }

    [Table("Stotras")]
    public class StotraInDb
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(8)]
        public string Name { get; set; }
        [MaxLength(10000)]
        public string Content { get; set; }
    }
}
