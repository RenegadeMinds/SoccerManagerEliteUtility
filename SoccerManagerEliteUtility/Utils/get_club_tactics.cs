using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMElite;

namespace SoccerManagerEliteUtility.Utils
{
    public class get_club_tactics
    {

        public static string Get_club_tactics( SMElite.get_club_tactics.GetClubTactics getClubTactics, SMElite.world world)
        {
            StringBuilder result = new StringBuilder();

            // result.AppendLine("Team Instructions");

            //result.AppendLine("Tackling Style: " + getClubTactics.Result.Data.t)

            foreach (var v in getClubTactics.Result.Data.TacticActions)
            {
                result.AppendLine("TEAM INSTRUCTIONS @ Time: " + v.Time.ToString());
                result.AppendLine(string.Format(StringTemplates.Tactics, "Goal Margin ", tactics.GetGoalMargin(Convert.ToInt32(v.GoalMargin))));
                result.AppendLine(string.Format(StringTemplates.Tactics, "Tackling Style ", tactics.tacklingstyle[v.TacklingStyle]));
                result.AppendLine(string.Format(StringTemplates.Tactics, "Passing Style ", tactics.passingstyle[v.PassingStyle]));
                result.AppendLine(string.Format(StringTemplates.Tactics, "Tempo ", tactics.tempo[v.Tempo]));
                result.AppendLine(string.Format(StringTemplates.Tactics, "Mentality ", tactics.mentality[v.Mentality]));
                result.AppendLine(string.Format(StringTemplates.Tactics, "Attacking ", tactics.attackingstyle[v.Attacking]));
                result.AppendLine(string.Format(StringTemplates.Tactics, "Pressing ", tactics.pressing[v.Pressing]));
                result.AppendLine("  ----");
                result.AppendLine("");

                result.AppendLine("PLAY STYLE");
                result.AppendLine(string.Format(StringTemplates.Tactics, "Counter Attack ", YesOrNo(v.CounterAttack)));
                result.AppendLine(string.Format(StringTemplates.Tactics, "Tight Marking ", YesOrNo(v.TightMarking)));
                result.AppendLine(string.Format(StringTemplates.Tactics, "Use Playmaker ", YesOrNo(v.UsePlaymaker)));
                result.AppendLine(string.Format(StringTemplates.Tactics, "Men Behind Ball ", YesOrNo(v.MenBehindBall)));
                result.AppendLine(string.Format(StringTemplates.Tactics, "Play Offside Trap ", YesOrNo(v.PlayOffside)));
                result.AppendLine(string.Format(StringTemplates.Tactics, "Use Target Man ", YesOrNo(v.UseTargetMan)));
                result.AppendLine("  ----");
                result.AppendLine("");

                result.AppendLine("PLAYER INSTRUCTIONS");
                result.AppendLine(string.Format(StringTemplates.Tactics, "Captain ", GetPlayerNameFromId(getClubTactics.Result.Data.TeamSheet[Convert.ToInt32(v.Captain)], world)));
                result.AppendLine(string.Format(StringTemplates.Tactics, "Freekicks ", GetPlayerNameFromId(getClubTactics.Result.Data.TeamSheet[Convert.ToInt32(v.FreeKicks)], world)));
                result.AppendLine(string.Format(StringTemplates.Tactics, "Playmaker ", GetPlayerNameFromId(getClubTactics.Result.Data.TeamSheet[Convert.ToInt32(v.Playmaker)], world)));
                result.AppendLine(string.Format(StringTemplates.Tactics, "Penalty Taker ", GetPlayerNameFromId(getClubTactics.Result.Data.TeamSheet[Convert.ToInt32(v.PenaltyTaker)], world)));
                result.AppendLine(string.Format(StringTemplates.Tactics, "Corner Taker ", GetPlayerNameFromId(getClubTactics.Result.Data.TeamSheet[Convert.ToInt32(v.CornerTaker)], world)));
                result.AppendLine(string.Format(StringTemplates.Tactics, "Target Man ", GetPlayerNameFromId(getClubTactics.Result.Data.TeamSheet[Convert.ToInt32(v.TargetMan)], world)));
                result.AppendLine("  ----");
                result.AppendLine("");

                result.AppendLine("LINE UP");

                foreach (var p in v.Lineup)
                {                    
                    result.AppendLine("  " + GetPlayerNameFromId(getClubTactics.Result.Data.TeamSheet[Convert.ToInt32(p)], world));
                }
                result.AppendLine("  ----");
                result.AppendLine("");
            }
            

            // And the team
            result.AppendLine("TEAM SHEET");
            foreach (var v in getClubTactics.Result.Data.TeamSheet)
            {
                result.AppendLine("  " + GetPlayerNameFromId(v, world));
            }

            return result.ToString();
        }

        private static string YesOrNo(long value)
        {
            string result = string.Empty;

            if (value == 0)
                result = "NO";
            else if (value == 1)
                result = "YES";
            else
                result = "Undefined";

            return result;
        }

        private static string GetPlayerNameFromId(long id, SMElite.world world)
        {
            int id2 = Convert.ToInt32(id);
            string result = string.Empty;

            try
            {
                result = world.players[id2].firstname + " " + world.players[id2].lastname + " - " + id.ToString();
            }
            catch
            {
                result = "Uknown - encountered an error";
            }

            return result;
        }


    }
}
