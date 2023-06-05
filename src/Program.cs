namespace RecordDemo
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Arrange record's objects
			PersonRecord rp1 = new PersonRecord("Hamed", "Khatami");
			PersonRecord rp2 = new PersonRecord("Hamed", "Khatami");
			PersonRecord rp3 = new PersonRecord("Fatemeh", "Seraj");

			// Arrange Class' objects
			PersonClass rc1 = new PersonClass("Hamed", "Khatami");
			PersonClass rc2 = new PersonClass("Hamed", "Khatami");
			PersonClass rc3 = new PersonClass("Fatemeh", "Seraj");

			// 1- Records have built-in tostring overriden
			Console.WriteLine("********************************");
			Console.WriteLine($"the value of the record is {rp1}");
			Console.WriteLine($"the value for the class is {rc1}");
			Console.WriteLine("********************************");

			// 2- Records have built-in equals overriden
			Console.WriteLine("********************************");
			Console.WriteLine($"Are both record's objects equal: {Equals(rp1, rp2)}");
			Console.WriteLine($"Are both class' objects equal: {Equals(rc1, rc2)}");
			Console.WriteLine("********************************");

			// 3- Becuase both record and class are reference types, so they addressed to different heaps
			Console.WriteLine("********************************");
			Console.WriteLine($"Have both record's objects same reference address: {ReferenceEquals(rp1, rp2)}");
			Console.WriteLine($"Have both classes's objects same reference address: {ReferenceEquals(rc1, rc2)}");
			Console.WriteLine("********************************");

			// 4- Records have built-in equality operators overriden
			Console.WriteLine("********************************");
			Console.WriteLine($"Are both record's objects equal by ==: {rp1 == rp2}");
			Console.WriteLine($"Are both class' objects equal by ==: {rc1 == rc2}");
			Console.WriteLine($"Are both record's objects not equal by ==: {rp1 != rp2}");
			Console.WriteLine($"Are both class' objects not equal by ==: {rc1 != rc2}");
			Console.WriteLine("********************************");

			// 5- Records have built-in equality operators overriden for just values
			Console.WriteLine("********************************");
			Console.WriteLine($"The hashcode of record 1 is: {rp1.GetHashCode()}");
			Console.WriteLine($"The hashcode of record 2 is: {rp2.GetHashCode()}");
			Console.WriteLine($"The hashcode of record 3 is: {rp3.GetHashCode()}");
			Console.WriteLine($"The hashcode of class 1 is: {rc1.GetHashCode()}");
			Console.WriteLine($"The hashcode of class 2 is: {rc2.GetHashCode()}");
			Console.WriteLine($"The hashcode of class 3 is: {rc3.GetHashCode()}");
			Console.WriteLine("********************************");

			// 6- Records have built-in deconstructor
			Console.WriteLine("********************************");
			var (fn, ln) = rp1;
			(string fn2, string ln2) deconst;
			rc1.Deconstruct(out deconst.fn2, out deconst.ln2);
			Console.WriteLine($"FirstName is {fn} and LastName is {ln}");
			Console.WriteLine($"FirstName is {deconst.fn2} and LastName is {deconst.ln2}");
			Console.WriteLine("********************************");

			// 7- In records you can create a new copy of object by changing only required property
			Console.WriteLine("********************************");
			var rp4 = rp1 with { LastName = "Hamed" };
			Console.WriteLine($"FirstName is {rp4.FirstName} and LastName is {rp4.LastName}");
			Console.WriteLine(ReferenceEquals(rp4, rp1));
			Console.WriteLine("********************************");

			Console.WriteLine("********************************");
			Console.WriteLine(new StudentRecord("Hamed", "Khatami"));
			Console.WriteLine("********************************");
		}
	}

	// Records are fancy classes (Have built-in tostring, equals, gethashcode, equality operator, deconstructor)
	// Records Are Reference Types
	// Records Are Immutable by default (not always)
	// Records Are Classes, There are lots of stuff around them
	// Records can copy by using with keywords easily
	public record PersonRecord(string FirstName, string LastName);

	// Records are immutable by defualt, but if you want to use tranditional getter and setter, it is not immutable anymore
	// Records can inherit and inherit from another record
	public record StudentRecord(string FirstName, string LastName)
	{
		public byte Age { get; set; }
	}

	public class PersonClass
	{
		public PersonClass(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}

		public string FirstName { get; private set; }

		public string LastName { get; private set; }

		public void Deconstruct(out string firstName, out string lastName)
		{
			firstName = this.FirstName;
			lastName = this.LastName;
		}
	}
}