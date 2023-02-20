using System;

namespace UoWRepo.Core.BaseDomain;

public interface INewsEtty: IBaseTEntity
{
    public int UserIdOwner { get; set; }

    public string Newstittel { get; set; }

    public string Newscontent { get; set; }

    public DateTime Newscreateddate { get; set; }

    public int Newspermission { get; set; }

    public int Newschangedbyid { get; set; }

    public int CategoryId { get; set; }

    public int Publicationtype { get; set; }

    public int Galleryid { get; set; }

    public string Newspresentation { get; set; }

    public DateTime Publicationdate { get; set; }

    public string Titleforurl { get; set; }

    public int HashtagsNewsId { get; set; }
}