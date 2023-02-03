using System.Xml.Serialization;

namespace Shelter
{
    [XmlRoot(ElementName = "Cats")]

	public class Cats
	{
		[XmlAttribute("Id")]
		public string id { get; set; }
		[XmlAttribute("cat_Name")]
		public string name { get; set; }
		[XmlAttribute("cat_Breed")]
		public string breed { get; set; }
		[XmlAttribute("cat_DominateColor")]
		public string dominateColor { get; set; }
		[XmlAttribute("cat_Size")]
		public string size { get; set; }

		public Cats()
		{

		}
		public Cats(string id, string name, string breed, string dominateColor, string size)
		{
			this.id = id;
			this.name = name;
			this.breed = breed;
			this.dominateColor = dominateColor;
			this.size = size;
		}

		public Cats(Cats cats)
		{
			this.id = cats.id;
			this.name = cats.name;
			this.breed = cats.breed;
			this.dominateColor = cats.dominateColor;
			this.size = cats.size;
		}



	}
}
