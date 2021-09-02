namespace Tickets.Application
{
    enum PriorityType
    {
        Critical,
        High,
        Medium,
        Low
    }
    enum Issue
    {
        Bug,
        UnhandledException,
        Interface_Issue

    }
    enum StateType
    {
        New,
        Pending,
        Open,
        Closed
    }
    enum StatusType
    {
        Not_Started,
        In_Progress,
        Finished,
        Cancelled
    }
    enum Title
    {
        Manager,
        TeamLeader,
        Devoleper

    }
}