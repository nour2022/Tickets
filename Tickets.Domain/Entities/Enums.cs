using System.ComponentModel.DataAnnotations;

namespace Tickets.Domain.Entities
{
    public enum PriorityType
    {

        [Display(Name = "Critical")]
        Critical = 1,
        [Display(Name = "High")]
        High,
        [Display(Name = "Medium")]
        Medium,
        [Display(Name = "Low")]
        Low
    }
    public enum Issue
    {
        [Display(Name = "Bug")]
        Bug = 1,
        [Display(Name = "Unhandled Exception")]
        UnhandledException,
        [Display(Name = " Interface Issue")]
        Interface_Issue

    }
    public enum StateType
    {
        [Display(Name = "New")]
        New = 1,
        [Display(Name = "Pending")]
        Pending,
        [Display(Name = "Open")]
        Open,
        [Display(Name = "Closed")]
        Closed
    }
    public enum StatusType
    {
        [Display(Name = "Not Started")]
        Not_Started = 1,
        [Display(Name = "In progress")]
        In_Progress = 2,
        [Display(Name = "Finished")]
        Finished = 3,
        [Display(Name = "Cancelled")]
        Cancelled = 4
    }
    public enum Title
    {
        Manager,
        TeamLeader,
        Devoleper,
        Tester,
        Client

    }
}