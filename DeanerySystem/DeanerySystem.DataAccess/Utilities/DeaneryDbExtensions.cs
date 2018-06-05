using System.Linq;
using DeanerySystem.DataAccess.Concrete;
using DeanerySystem.DataAccess.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeanerySystem.DataAccess.Utilities
{
    public static class DeaneryDbExtensions
    {
        public static bool AllMigrationsApplied(this DeaneryDbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public static void EnsureSeeded(this DeaneryDbContext context)
        {
            var identityUtilityManager = new IdentityUtilityManager(context);
            identityUtilityManager.InitRoles();
            identityUtilityManager.InitAdministrator();
            DataBaseUtilities.FeedDataBase(context);
        }
    }
}
