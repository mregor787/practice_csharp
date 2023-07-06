using System;

namespace Task1 
{
    public class Student : IEquatable<Student>
    {
        private string _surname;
        private string _name;
        private string _midname;
        private string _group;
        private string _chosenPractice;
        
        public Student (string surname, string name, string midname, string group, string chosenPractice)
        {
            try 
            {
                _surname = surname ?? throw new ArgumentNullException(nameof(surname));
                _name = name ?? throw new ArgumentNullException(nameof(name));
                _midname = midname ?? throw new ArgumentNullException(nameof(midname));
                _group = group ?? throw new ArgumentNullException(nameof(group));
                _chosenPractice = chosenPractice ?? throw new ArgumentNullException(nameof(chosenPractice));
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public string Surname { get { return _surname; }}
        public string Name { get { return _name; }}
        public string Midname { get { return _midname; }}
        public string Group { get { return _group; }}
        public string ChosenPractice { get { return _chosenPractice; }}
        public int CourseNumber
        {
            get
            {
                return int.Parse(char.ToString(Group[Group.IndexOf("-") + 1]));
            }
        }
        public override string ToString()
        {
            return $"{Surname} {Name} {Midname} {Group} {ChosenPractice}";
        }
        public bool Equals(Student? st)
        {
            if (st == null) { return false; }
            return st.Surname == Surname && st.Name == Name && st.Midname == Midname 
            && st.Group == Group && st.ChosenPractice == ChosenPractice;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) { return false; }
            if (obj is Student st) { return Equals(st); }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Surname, Name, Midname, Group, ChosenPractice);
        }
    }
}