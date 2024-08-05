using InterviewExercise.Dtos.Interfaces;

namespace InterviewExercise.Dtos
{
    public abstract class DtoBase : IDtoBase
    {
        protected DtoBase()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
