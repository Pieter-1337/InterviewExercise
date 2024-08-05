using InterviewExercise.Domain.Interfaces;

namespace InterviewExercise.Domain
{
    public abstract class EntityBase: IEntityBase
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
