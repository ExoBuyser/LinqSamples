<Query Kind="Program">
  <Connection>
    <ID>6dcde99c-9d8e-425d-b0c0-bf57ab396017</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

void Main()
{
	// find artists who have a C in their name, order alphabetically
	//assume that the user entered a partial name of an artist
	//on a webform or webpage and submit the string to my controller
	//as a parameter
	var partialname = "C";
	
	//use user defined class to select the specified fields
	//off the row instance of Artists
	var results = from x in Artists
				where x.Name.Contains(partialname)
				orderby x.Name
				select new ArtistList{
					ArtistId = x.ArtistId,
					Name = x.Name
				};
				
	results.Dump("Artist List");
	
	
	//since the subquery is defined in the DTOClass
	//as a List<T>, you Must cast the subquery with .ToList()
	var resultsDTO = from x in Artists
				select new DTOClass{
					Artist = x.Name,
					Albums = (from y in x.Albums
							select new POCOClass{
								Title = y.Title,
								Year = y.ReleaseYear
							}).ToList()
				};
				resultsDTO.Dump("Artist Albums");
}

// Define other methods and classes here
public class ArtistList
{
	public int ArtistId {get;set;}
	public string Name {get;set;}
}

public class DTOClass
{
	//can have plain fields and collection type fields
	public string Artist{get; set;}
	public List<POCOClass> Albums {get;set;}
}

public class POCOClass
{
//can have plain(flat) fields

public string Title{get;set;}
public int Year{get;set;}
}