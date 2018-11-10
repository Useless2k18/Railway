namespace BusinessLogicWPF.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RailwayDbContext : DbContext
    {
        public RailwayDbContext()
            : base("name=Railway")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<DaysAvailable> DaysAvailables { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<PassengerTicket> PassengerTickets { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<RouteHasStation> RouteHasStations { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<Train> Trains { get; set; }
        public virtual DbSet<TrainClass> TrainClasses { get; set; }
        public virtual DbSet<TrainStatus> TrainStatus { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<DaysAvailable>()
                .Property(e => e.AvailableDays)
                .IsUnicode(false);

            modelBuilder.Entity<Passenger>()
                .Property(e => e.PassengerNameRecord)
                .IsUnicode(false);

            modelBuilder.Entity<Passenger>()
                .Property(e => e.CoachNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Passenger>()
                .Property(e => e.PassengerName)
                .IsUnicode(false);

            modelBuilder.Entity<Passenger>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Passenger>()
                .Property(e => e.BookedBy)
                .IsUnicode(false);

            modelBuilder.Entity<PassengerTicket>()
                .Property(e => e.PassengerNameRecord)
                .IsUnicode(false);

            modelBuilder.Entity<PassengerTicket>()
                .Property(e => e.SourceId)
                .IsUnicode(false);

            modelBuilder.Entity<PassengerTicket>()
                .Property(e => e.DestinationId)
                .IsUnicode(false);

            modelBuilder.Entity<PassengerTicket>()
                .Property(e => e.ClassType)
                .IsUnicode(false);

            modelBuilder.Entity<PassengerTicket>()
                .Property(e => e.ReservationStatus)
                .IsUnicode(false);

            modelBuilder.Entity<PassengerTicket>()
                .Property(e => e.BookedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.AvailableDate)
                .IsUnicode(false);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.EmailId)
                .IsUnicode(false);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.PassengerNameRecord)
                .IsUnicode(false);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.ReservationDate)
                .IsUnicode(false);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.ReservationStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Route>()
                .Property(e => e.StationId)
                .IsUnicode(false);

            modelBuilder.Entity<Route>()
                .Property(e => e.ArrivalTime)
                .IsUnicode(false);

            modelBuilder.Entity<Route>()
                .Property(e => e.DepartureTime)
                .IsUnicode(false);

            modelBuilder.Entity<RouteHasStation>()
                .Property(e => e.StationId)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.StationId)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.StationName)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.StationLocation)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.Trains)
                .WithOptional(e => e.Station)
                .HasForeignKey(e => e.DestinationId);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.Trains1)
                .WithOptional(e => e.Station1)
                .HasForeignKey(e => e.SourceId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Train>()
                .Property(e => e.TrainName)
                .IsUnicode(false);

            modelBuilder.Entity<Train>()
                .Property(e => e.TrainType)
                .IsUnicode(false);

            modelBuilder.Entity<Train>()
                .Property(e => e.SourceStation)
                .IsUnicode(false);

            modelBuilder.Entity<Train>()
                .Property(e => e.DestinationStation)
                .IsUnicode(false);

            modelBuilder.Entity<Train>()
                .Property(e => e.SourceId)
                .IsUnicode(false);

            modelBuilder.Entity<Train>()
                .Property(e => e.DestinationId)
                .IsUnicode(false);

            modelBuilder.Entity<TrainStatus>()
                .Property(e => e.AvailableDate)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.EmailId)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.SecurityQuestion)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.SecurityAnswer)
                .IsUnicode(false);
        }
    }
}
