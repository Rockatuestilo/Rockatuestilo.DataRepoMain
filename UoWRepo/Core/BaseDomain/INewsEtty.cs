using System;

namespace UoWRepo.Core.BaseDomain;

public interface INewsEtty: IBaseTEntity
{
    public int UserIdOwner { get; set; }

    public string NewsTitle { get; set; }

    public string NewsContent { get; set; }

    public DateTime NewsCreatedDate { get; set; }

    public int NewsPermission { get; set; }

    public int NewsChangedById { get; set; }

    public int CategoryId { get; set; }

    public int PublicationType { get; set; }

    public int GalleryId { get; set; }

    public string NewsPresentation { get; set; }

    public DateTime PublicationDate { get; set; }

    public string TitleForUrl { get; set; }

    public int HashtagsNewsId { get; set; }
}