﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XDATA.Data
{
    public class Star : EntityBase
    {
        public string S_JName { get; set; }
        public string S_CName { get; set; }
        public string S_EName { get; set; }
        public DateTime S_Birthday { get; set; } = DateTime.MinValue;
        public int S_Height { get; set; } = 0;
        public string S_Cup { get; set; }
        public int S_BWH_B { get; set; } = 0;
        public int S_BWH_W { get; set; } = 0;
        public int S_BWH_H { get; set; } = 0;
        public string S_Hometown { get; set; }
        public virtual AvatarFile S_AvatarFiles { get; set; }
        public virtual ICollection<Movie> S_Movies { get; set; }

        public Star()
        {
            this.UID = Guid.NewGuid();
        }

        public Star(string jname) : this()
        {
            this.S_JName = jname.Trim();
        }
        /*
        public IQueryable<Star> WhereByKeyword(IQueryable<Star> query, string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return query;
            }
            return from a in query
                   where a.CName.Contains(keyword)
                         || a.JName.Contains(keyword)
                         || a.EName.Contains(keyword)
                   select a;
        }

        public string GetJName(IQueryable<Star> query, Guid uid)
        {
            return query.Where(x => x.UID == uid).Select(x => x.S_JName).FirstOrDefault();
        }
        */
    }
}
