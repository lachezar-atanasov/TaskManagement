namespace TaskManagement.Commands.Enums
{
    public enum CommandType
    {
        Default,
        Help,
        CreateTeam,
        AddMember,
        AddMemberToTeam,
        CreateNewBoardInTeam,
        AddCommentToTask,
        CreateNewBugInBoard,
        ChangeBugPriority,
        ChangeBugSeverity,
        ChangeBugStatus,
        AddBugFixSteps,
        ListBugs,
        CreateNewFeedbackInBoard,
        CreateNewStoryInBoard,
        AssignTaskToMember,
        UnassignTaskFromMember,
        ListAllTasks,
        ListAllMembers,
        ListAllTeams,
        ListTasksWithAssignee,
        ListStories,
        ListFeedbacks,
        ListAllTeamMembers,
        ListAllTeamBoards,
        ShowMemberActivity,
        ShowTeamActivity,
        ShowBoardActivity,
        ChangeStoryStatus,
        ChangeStorySize,
        ChangeStoryPriority,
        ChangeFeedbackRating,
        ChangeFeedbackStatus,
    }
}



