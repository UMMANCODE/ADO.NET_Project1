using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp40 {
    internal class Brand {

        private static int _id = 0;
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? Year { get; set; }

        public Brand(string? name, DateTime? year) {
            Id = ++_id;
            Name = name;
            Year = year;
        }

        public Brand() {
        }

        public override string? ToString() {
            return $"Id: {Id}, Name: {Name}, Year: {Year}";
        }
    }
}
