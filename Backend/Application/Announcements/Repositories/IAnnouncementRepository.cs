using Application.Bazaar.BazzarRepositories;
using Domain.Models;
using Domain.StronglyTypes;

namespace Application.Announcements.Repositories; 

public interface IAnnouncementRepository : IRepository<Announcement,AnnouncementId>
{
}
