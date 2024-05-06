using System;

namespace TaskManagement.Commands.Enums
{
    public enum CommandType
    {
        Default,
        AddMember,
        ShowAllMembers,
        ShowMemberActivity,
        CreateTeam,
        ShowAllTeams,
        ShowTeamActivity,
        ShowBoardActivity,
        AddMemberToTeam,
        ShowAllTeamMembers,
        CreateNewBoardInTeam,
        ShowAllTeamBoards,
        CreateNewBugInBoard,
        CreateNewFeedbackInBoard,
        CreateNewStoryInBoard,
        ChangeBugPriority,
        ChangeBugSeverity,
        ChangeBugStatus,
        ChangeStoryStatus,
        ChangeStorySize,
        ChangeStoryPriority,
        ChangeFeedbackRating,
        ChangeFeedbackStatus,
        AssignTaskToMember,
        UnassignTaskFromMember,
        ListAllTasks,
        ListTasksWithAssignee,
        ListBugs,
        ListStories,
        ListFeedbacks,
        AddCommentToTask

    }
}



