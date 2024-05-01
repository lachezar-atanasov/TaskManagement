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
        AddPersonToTeam,
        ShowAllTeamMembers,
        CreateNewBoardInTeam,
        ShowAllTeamBoards,
        CreateNewTask,
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



