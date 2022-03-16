namespace Aitor.BuildingBlocks.CQRS
{
    public enum CommandResultTypeEnum
    {
        Success,
        InvalidInput,
        UnprocessableEntity,
        Conflict,
        NotFound
    }
}
