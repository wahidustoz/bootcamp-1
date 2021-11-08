namespace tasks.Mapper
{
    public static class ModelEntityMapper
    {
        public static Entity.Task ToTaskEntity(this Model.NewTask newTask)
        {
            return new Entity.Task(
                title: newTask.Title,
                description: newTask.Description,
                tags: string.Join(',', newTask.Tags),
                location: string.Format($"{newTask.Location.Latitude},{newTask.Location.Longitude}"),
                atATime: newTask.AtATime,
                onADay: newTask.OnADay,
                repeat: newTask.Repeat.Value.ToEntityETaskRepeat()
                // TO-DO: Finish remaining properties.
            );
        }

        public static Entity.ETaskRepeat ToEntityETaskRepeat(this Model.ETaskRepeat repeat)
        {
            return repeat switch
            {
                Model.ETaskRepeat.Daily => Entity.ETaskRepeat.Daily,
                // TO-DO: Finish remaining values
                _ => Entity.ETaskRepeat.Never
            };
        }
    }
}