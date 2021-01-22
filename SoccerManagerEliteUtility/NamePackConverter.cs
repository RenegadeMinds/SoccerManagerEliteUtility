using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Csv;

namespace SoccerManagerEliteUtility
{
    public partial class NamePackConverter : Form
    {
        public NamePackConverter()
        {
            InitializeComponent();
        }

        private void NamePackConverter_Load(object sender, EventArgs e)
        {

        }



        public const char SECTION_DELIMITER = '\u0001';
        public const char ROW_DELIMITER = '\u0002';
        public const char FIELD_DELIMITER = '\u0003';

        public const char SAVE_SPACER = '│';

        public const string NAME_PACK_FILE_NAME = "NamePack-2019-10";
        //public const string DATA_FILE_NAME = "DataFile-2019-02";

        public const string DEFAULT_NAME_PACK_NAME = "DefaultNamePack1";
        public const string DEFAULT_DATA_PACK_NAME = "EliteDataFile";

        public const byte CONST_CLUBDATA_SECTION = 2;
        public const byte CONST_STADIUMDATA_SECTION = 3;
        public const byte CONST_PLAYERDATA_SECTION = 4;
        public const byte CONST_DEFAULT_CLUBDATA_SECTION = 1;
        public const byte CONST_DEFAULT_STADIUMDATA_SECTION = 2;
        public const byte CONST_DEFAULT_PLAYERDATA_SECTION = 3;


        public string NamePackPlayerImageURL;
        public string NamePackClubImageURL;
        public string NamePackLeagueImageURL;
        public string NamePackCupImageURL;

        public int g_ClubDataLastClubIndex = 0;
        public bool LoadedData = false;


        Dictionary<int, SMElite.player> players = new Dictionary<int, SMElite.player>();
        Dictionary<int, SMElite.club> clubs = new Dictionary<int, SMElite.club>();
        Dictionary<int, SMElite.stadium> stadiums = new Dictionary<int, SMElite.stadium>();

        /// <summary>
        /// Whether from the web or resources, processes the name pack data and populates the data structures with it
        /// </summary>
        /// <param name="data"></param>
        public void ProcessNamePackData(string data)
        {
            string[] sections = data.Split(SECTION_DELIMITER);

            List<int> existing_clubs = new List<int>();
            List<int> existing_players = new List<int>();
            List<int> existing_stadiums = new List<int>();

            existing_clubs = SMElite.SqlReports.GetAllClubIds();
            existing_players = SMElite.SqlReports.GetAllPlayerIds();
            existing_stadiums = SMElite.SqlReports.GetAllStadiumIds();

            players = new Dictionary<int, SMElite.player>();
            clubs = new Dictionary<int, SMElite.club>();
            stadiums = new Dictionary<int, SMElite.stadium>();

            if (sections.Length < 2)
            {
                Console.WriteLine("ERROR - Did not get enough sections of data");
            }
            else
            {
                Console.WriteLine("Got " + sections.Length + " name pack data sections");

                // get URLS for any custom NamePack Images
                if (sections.Length > 8)
                {
                    this.NamePackPlayerImageURL = sections[8];
                }
                if (sections.Length > 9)
                {
                    this.NamePackClubImageURL = sections[9];
                }
                if (sections.Length > 10)
                {
                    this.NamePackLeagueImageURL = sections[10];
                }
                if (sections.Length > 11)
                {
                    this.NamePackCupImageURL = sections[11];
                }

                // SECTIONS[0] is player data
                string[] nameRows = sections[0].Split(ROW_DELIMITER);
                if (nameRows.Length > 1)
                {
                    for (var i = 0; i < nameRows.Length; i++)
                    {
                        // Player Data
                        string[] fields = nameRows[i].Split(FIELD_DELIMITER);
                        // Find player index to load name pack details for

                        int playerID = Int32.Parse(fields[0]);
                        if (existing_players.Contains(playerID)) 
                        {
                            SMElite.player player = new SMElite.player();
                            player.id = playerID.ToString();
                            player.firstname = fields[1];
                            player.lastname = fields[2];
                            if (fields.Length > 5)
                            {
                                if (fields[4] == "1")
                                {
                                    // is a custom data pack Image - use full custom URL
                                }
                                else
                                {
                                    player.image = fields[5];
                                }
                            }

                            players.Add(playerID, player);
                        }
                    }
                }
                else
                {
                    // No player Data in file, set to numbers
                    foreach (int playerID in existing_players) 
                    {
                        SMElite.player player = new SMElite.player();
                        player.id = playerID.ToString();
                        player.firstname = "Player #";
                        player.lastname = playerID.ToString();
                        player.image = string.Empty;

                        players.Add(playerID, player);
                    }
                }

                // SECTIONS[1] is club data
                nameRows = sections[1].Split(ROW_DELIMITER);
                if (nameRows.Length > 1)
                {
                    for (var i = 0; i < nameRows.Length; i++)
                    {
                        // Club Data
                        string[] fields = nameRows[i].Split(FIELD_DELIMITER);
                        SMElite.club club = new SMElite.club();
                        short clubID = short.Parse(fields[0]);
                        if (existing_clubs.Contains(clubID)) 
                        {
                            club.id = clubID.ToString();
                            club.name = fields[1];
                            club.image = fields[3];
                        } 
                        else
                        {
                            club.id = clubID.ToString();
                            club.name = "Club #" + clubID.ToString();
                            club.image = string.Empty;
                        }
                        clubs.Add(clubID, club);
                    }
                }
                else
                {
                    // No Club Data in file, set to numbers
                    foreach (short clubId in existing_clubs) 
                    {
                        SMElite.club club = new SMElite.club();
                        club.id = clubId.ToString();
                        club.name = "Club #" + clubId.ToString();
                    }
                }

                // SECTIONS[12] is stadium data
                // Not adding this in as not using them for stats so far
                if (sections.Length > 12)
                {
                    // Stadium Data
                    nameRows = sections[12].Split(ROW_DELIMITER);
                    if (nameRows.Length > 1)
                    {
                        for (var i = 0; i < nameRows.Length; i++)
                        {
                            string[] fields = nameRows[i].Split(FIELD_DELIMITER);
                            //
                            {
                                int stadiumID = Int32.Parse(fields[0]);
                                if (true) 
                                {

                                }
                            }
                        }
                    }
                }

            } // End else -- creates players, clubs, and stadiums




        }

        private void btnOpenDataPack_Click(object sender, EventArgs e)
        {
            DialogResult dr = ofdOpenDataPack.ShowDialog();

            if (dr != DialogResult.OK)
                return;
            if (!ofdOpenDataPack.CheckFileExists)
                return;

            string data = string.Empty;

            using (StreamReader sr = File.OpenText(ofdOpenDataPack.FileName))
            {                
                data = sr.ReadToEnd();                
            }

            ProcessNamePackData(data);

        }

        private void btnProcessDataPack_Click(object sender, EventArgs e)
        {
            ProcessPlayers();

            ProcessClubs();
        }

        private void ProcessClubs()
        {
            var options = new CsvOptions // Defaults
            {
                RowsToSkip = 0, // Allows skipping of initial rows without csv data
                SkipRow = (row, idx) => string.IsNullOrEmpty(row) || row[0] == '#',
                Separator = '\0', // Autodetects based on first row
                TrimData = false, // Can be used to trim each cell
                Comparer = null, // Can be used for case-insensitive comparison for names
                HeaderMode = HeaderMode.HeaderPresent, // Assumes first row is a header row
                ValidateColumnCount = false, // Checks each row immediately for column count
                ReturnEmptyForMissingColumn = false, // Allows for accessing invalid column names
                Aliases = null, // A collection of alternative column names
                AllowNewLineInEnclosedFieldValues = false, // Respects new line (either \r\n or \n) characters inside field values enclosed in double quotes.
                AllowBackSlashToEscapeQuote = false, // Allows the sequence "\"" to be a valid quoted value (in addition to the standard """")
                AllowSingleQuoteToEncloseFieldValues = false, // Allows the single-quote character to be used to enclose field values
                NewLine = Environment.NewLine // The new line string to use when multiline field values are read (Requires "AllowNewLineInEnclosedFieldValues" to be set to "true" for this to have any effect.)
            };

            var columnNames = new[] { "Id", "Name", "Logo" };

            int club_count = clubs.Count;
            //var vr = new[] { new[] { "1", "first", "last" } };
            List<string[]> lines = new List<string[]>();

            // This is a cloned array for all club ids. 
            // We use it to remove clubs that we've added to our CSV variables.
            // After, we add in any missing ones.
            string[] cs = (string[])SMElite.Utilities.valid_clubs.Clone();


            foreach (var c in clubs)
            {
                if (SMElite.Utilities.valid_clubs.Contains(c.Value.id))
                {
                    string[] line = new string[3] { c.Value.id, c.Value.name, c.Value.image };
                    lines.Add(line);
                    // Remove existing club
                    cs = cs.Where(val => val != c.Value.id).ToArray();
                }
            }

            // Add in any clubs IDs that are in the game but not in the pack we loaded.
            foreach(var c in cs)
            {
                string[] line = new string[3] { c, "Club #" + c, "" };
                lines.Add(line);
            }

            var csv = CsvWriter.WriteToText(columnNames, lines, ',');
            File.WriteAllText("clubs " + GetDateTime() + ".csv", csv);
        }


        private void ProcessPlayers()
        {
            var options = new CsvOptions // Defaults
            {
                RowsToSkip = 0, // Allows skipping of initial rows without csv data
                SkipRow = (row, idx) => string.IsNullOrEmpty(row) || row[0] == '#',
                Separator = '\0', // Autodetects based on first row
                TrimData = false, // Can be used to trim each cell
                Comparer = null, // Can be used for case-insensitive comparison for names
                HeaderMode = HeaderMode.HeaderPresent, // Assumes first row is a header row
                ValidateColumnCount = false, // Checks each row immediately for column count
                ReturnEmptyForMissingColumn = false, // Allows for accessing invalid column names
                Aliases = null, // A collection of alternative column names
                AllowNewLineInEnclosedFieldValues = false, // Respects new line (either \r\n or \n) characters inside field values enclosed in double quotes.
                AllowBackSlashToEscapeQuote = false, // Allows the sequence "\"" to be a valid quoted value (in addition to the standard """")
                AllowSingleQuoteToEncloseFieldValues = false, // Allows the single-quote character to be used to enclose field values
                NewLine = Environment.NewLine // The new line string to use when multiline field values are read (Requires "AllowNewLineInEnclosedFieldValues" to be set to "true" for this to have any effect.)
            };

            var columnNames = new[] { "Id", "First Name", "Last Name", "Photo" };

            int player_count = players.Count;
            //var vr = new[] { new[] { "1", "first", "last" } };
            List<string[]> lines = new List<string[]>();


            // This is a cloned array for all player ids. 
            // We use it to remove players that we've added to our CSV variables.
            // After, we add in any missing ones.
            string[] ps = (string[])SMElite.Utilities.valid_players.Clone();

            foreach (var p in players)
            {
                if (SMElite.Utilities.valid_players.Contains(p.Value.id))
                {
                    string[] line = new string[4] { p.Value.id, p.Value.firstname, p.Value.lastname, p.Value.image != null ? p.Value.image : string.Empty };
                    lines.Add(line);
                    // Remove existing player
                    ps = ps.Where(val => val != p.Value.id).ToArray();
                }
            }

            // Add in any clubs IDs that are in the game but not in the pack we loaded.
            foreach (var p in ps)
            {
                string[] line = new string[4] { p, "Player #" + p, "", "" };
                lines.Add(line);
            }

            var csv = CsvWriter.WriteToText(columnNames, lines, ',');
            File.WriteAllText("players " + GetDateTime() + ".csv", csv);

        }


        private static string GetDateTime()
        {
            string result;

            DateTime dt = DateTime.Now;
            result = dt.ToString("yyyy-MM-dd HH-mm-ss");

            return result;
        }



    }
}
