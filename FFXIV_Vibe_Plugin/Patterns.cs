﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV_Vibe_Plugin {

  public class Patterns {
    private int __count = 0;
    private readonly List<Pattern> List = new();

    public Patterns() {
      this.Add(new Pattern("intensity", "")); // Special pattern
      this.Add(new Pattern("otherPattern", "10:500|20:500|0:0"));
    }

    public List<Pattern> Get() {
      return this.List;
    }

    public void Add(Pattern pattern) {
      pattern.Index = this.__count++;
      List.Add(pattern);
    }

    public void Update(Pattern pattern, string name, string value) {
      /* TODO: Get the correct pattern based on pattern name
      pattern.SetName(pattern.Name);
      pattern.SetValue(pattern.Value);
      */
    }
  }

  public class Pattern {
    public int Index = -1;
    public string Name = "pattern";
    public string Value = "10:1000";
    public Pattern(string name="pattern", string value="10:1000") {
      this.Name = name;
      this.Value = value;
    }
  }
}
