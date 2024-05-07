using System;

namespace TaskManagement.Commands.Enums
{
    public enum CommandType
    {
        Default,
        Help,
        AddMember,
        CreateTeam,
        AddMemberToTeam,
        CreateNewBoardInTeam,
        CreateNewBugInBoard,
        CreateNewFeedbackInBoard,
        CreateNewStoryInBoard,
        AssignTaskToMember,
        UnassignTaskFromMember,
        ListAllTasks,
        ListTasksWithAssignee,
        ListBugs,
        ListStories,
        ListFeedbacks,
        AddCommentToTask,
        ShowAllMembers,
        ShowAllTeams,
        ShowAllTeamMembers,
        ShowAllTeamBoards,
        ShowMemberActivity,
        ShowTeamActivity,
        ShowBoardActivity,
        ChangeBugPriority,
        ChangeBugSeverity,
        ChangeBugStatus,
        ChangeStoryStatus,
        ChangeStorySize,
        ChangeStoryPriority,
        ChangeFeedbackRating,
        ChangeFeedbackStatus,
    }
}



