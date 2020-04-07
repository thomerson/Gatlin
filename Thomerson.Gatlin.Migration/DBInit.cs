using FluentMigrator;
using System.IO;

namespace Thomerson.Gatlin.Migration
{
    [Migration(202004062200)]
    public class DBInit : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.Table("NLog_Log");
        }

        public override void Up()
        {
            Execute.Script($"{ Directory.GetCurrentDirectory()}\\Scripts\\dbo.NLog_Log.sql");
        }
    }
}
