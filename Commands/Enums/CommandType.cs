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
        AddMemberToTeam,
        ShowAllTeamMembers,
        CreateNewBoardInTeam,
        ShowAllTeamBoards,
        CreateNewBugInBoard,
        ChangeBugDetail,
        ChangeStoryDetail,
        ChangeFeedbackDetail,
        AssignTaskToPerson,
        UnassignTaskToPerson,
        ListTasks,
        ListSubTask,
        ListTasksWithAsignee

    }
}



