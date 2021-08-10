using System;
using System.Collections.Generic;
using System.Text;

namespace TvShowsList
{
    class TvShow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsFavorite { get; set; }
        public TvShow(int id, string name, bool isFavorite)
        {
            Id = id;
            Name = name;
            IsFavorite = isFavorite;
        }
    }
}
