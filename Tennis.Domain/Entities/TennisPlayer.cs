using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tennis.Domain.ValueObjects;

namespace Tennis.Domain.Entities
{
    public class TennisPlayer
    {
        public int Id { get; private set; }  
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string ShortName { get; private set; }
        public string Sex { get; private set; }
        public Country Country { get; private set; }
        public string Picture { get; private set; }
        public PlayerData Data { get; private set; } 

        public TennisPlayer(int id, string firstName, string lastName, string shortName, string sex, Country country, string picture, PlayerData data)
        {
            // Validations basées sur les règles métier du domaine
            if (id <= 0)
                throw new ArgumentException("Id must be greater than 0.");

            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name is required.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name is required.");

            if (string.IsNullOrWhiteSpace(sex))
                throw new ArgumentException("Sex is required.");

            Id = id;
            FirstName = firstName;
            LastName = lastName;
            ShortName = shortName;
            Sex = sex;
            Country = country ?? throw new ArgumentNullException(nameof(country)); // Le pays ne peut pas être null
            Picture = picture;
            Data = data ?? throw new ArgumentNullException(nameof(data)); // Les statistiques ne peuvent pas être null
        }
    }
}
