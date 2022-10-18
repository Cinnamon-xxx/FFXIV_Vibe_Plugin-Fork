﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FFXIV_Vibe_Plugin.Commons;

namespace FFXIV_Vibe_Plugin.Migrations {
  internal class Migration {
    private readonly Configuration configuration;
    private readonly Logger logger;

    public Migration(Configuration configuration, Logger logger) {
      this.configuration = configuration;
      this.logger = logger;
      
    }

    public bool Patch_2_0_0_to_2_1_0_config_profile() {
      var configuration = this.configuration;
      var logger = this.logger;
      //
      if(configuration.Version == 0 && configuration != null) {
        ConfigurationProfile preset = new() {
          Name = "Migrated from 2.0.0",
          VERBOSE_SPELL = configuration.VERBOSE_SPELL,
          VERBOSE_CHAT = configuration.VERBOSE_CHAT,
          VIBE_HP_TOGGLE = configuration.VIBE_HP_TOGGLE,

          VIBE_HP_MODE = configuration.VIBE_HP_MODE,
          MAX_VIBE_THRESHOLD = configuration.MAX_VIBE_THRESHOLD,
          AUTO_CONNECT = configuration.AUTO_CONNECT,
          AUTO_OPEN = configuration.AUTO_OPEN,
          PatternList = configuration.PatternList,
          BUTTPLUG_SERVER_HOST = configuration.BUTTPLUG_SERVER_HOST,
          BUTTPLUG_SERVER_PORT = configuration.BUTTPLUG_SERVER_PORT,
          TRIGGERS = configuration.TRIGGERS,
          VISITED_DEVICES = configuration.VISITED_DEVICES
        };

        configuration.Version = 1;
        this.configuration.Profiles = new();
        configuration.Profiles.Add(preset);
        configuration.Save();
        logger.Warn("Migration from 2.0.0 to 2.1.0 using profiles done successfully");
        return true;
      }
      return false;
    }


  }

 
}