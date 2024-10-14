using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.Domain.ValueObjects
{
    public class Country : IEquatable<Country>
    {
        public Country(string code, string picture)
        {
            Code = code;
            Picture = picture;
        }

        public string Code { get; }
        public string Picture { get; }

        public bool Equals(Country? other)
        {
            if (other == null)
                return false;
            return Code == other.Code ;

        }
        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }
    }
}