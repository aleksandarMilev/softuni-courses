namespace CarRacing.Models.Racers.Contracts
{
    using CarRacing.Enums;
    using Cars.Contracts;

    public interface IRacer
    {
        string Username { get; }

        RacingBehavior RacingBehavior { get; }

        int DrivingExperience { get; }

        ICar Car { get; }

        void Race();

        bool IsAvailable();
    }
}
