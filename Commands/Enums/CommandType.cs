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
        AddCommentToTask,
        CreateNewBugInBoard,
        CreateNewFeedbackInBoard,
        CreateNewStoryInBoard,
        AssignTaskToMember,
        UnassignTaskFromMember,
        ListAllTasks,
        ListAllMembers,
        ListAllTeams,
        ListTasksWithAssignee,
        ListBugs,
        ListStories,
        ListFeedbacks,
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



