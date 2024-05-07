using System;

namespace TaskManagement.Commands.Enums
{
    public enum CommandType
    {
        Default,
        Help,
        ListAllTasks,
        ListAllMembers,
        ListAllTeams,
        AddMember,
        CreateTeam,
        AddMemberToTeam,
        CreateNewBoardInTeam,
        CreateNewBugInBoard,
        CreateNewFeedbackInBoard,
        CreateNewStoryInBoard,
        AssignTaskToMember,
        UnassignTaskFromMember,
        ListTasksWithAssignee,
        ListBugs,
        ListStories,
        ListFeedbacks,
        AddCommentToTask,
        ListAllTeamMembers,
        ListAllTeamBoards,
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



