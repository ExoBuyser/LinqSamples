<Query Kind="Expression">
  <Connection>
    <ID>6dcde99c-9d8e-425d-b0c0-bf57ab396017</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//list all Artist and their albums
from x in Artists
select new {
	Artist = x.Name,
	Albums = from y in x.Albums
			select new {
				Title = y.Title,
				Year = y.ReleaseYear
			}
}