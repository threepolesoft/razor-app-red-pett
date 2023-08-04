using Microsoft.EntityFrameworkCore;
using ReDpett_API.Modal;

namespace ReDpett_API.Service
{
    public class REcontext : DbContext
    {

        public REcontext(DbContextOptions<REcontext> options) : base(options)
        {
            //EntityFrameworkCore\Add-Migration db
        }
        //public REcontext() //: base("name=REcontext") 
        //{

        //}
        //public DbSet<User>? Users { get; set; }
        public DbSet<OrganizationPasscode> OrganizationPasscode { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<ResidentType> ResidentTypes { get; set; }  
        public DbSet<Passcode> Passcodes { get; set; }
        
        public  DbSet<Projects> projects { get; set; }
        public  DbSet<FileData> FileDatas { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Roles> ROles { get; set; }
        //
        public DbSet<FETPProgram> FETPPrograms { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Frontline36> Frontline36 { get; set; }
        public DbSet<codetypeclass> codetypeclass { get; set; }
        public DbSet<CodeReqWritingType1> codereqwritingtype1 { get; set; }
        public DbSet<CodeOneHealth11> codeonehealth11 { get; set; }
        public DbSet<CodeOneHealth21> codeonehealth21 { get; set; }
        public DbSet<TraineeInformation6> TraineeInformation6 { get; set; }
        public DbSet<Codecurrentprofession1> codecurrentprofession1 { get; set; }
        public DbSet<codeinstituteaff1> codeinstituteaff1 { get; set; }
        public DbSet<Codeorganizationtype1> codeorganizationtype1 { get; set; }
        public DbSet<CodeFieldSites123_universitytraining> codefieldsites123university_training { get; set; }
        public DbSet<Codequalifyingdegree1> codequalifyingdegree1 { get; set; }
        public DbSet<Codefetptrack1> codefetptrack1 { get; set; }
        public DbSet<CodeGender> codegender1 { get; set; }


        //public DbSet<codeprojectstatus1> codeprojectstatus1 { get; set; }


    }
}
