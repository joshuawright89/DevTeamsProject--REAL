using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    //P.O.C.O.
    public class Developer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HasPluralSight { get; set; }
        private static int _current = 0;
        private static int NextId => Interlocked.Increment(ref _current);
        public int Id { get; set; } = NextId;

        public Developer() { }  //Overloading
        public Developer(string firstName, string lastName, bool hasPluralSight, int idNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            HasPluralSight = hasPluralSight;
        }

        public Developer(string v1, string v2, bool v3)
        {
        }
    }
}
