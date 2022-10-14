using System.Collections;
using System.Collections.Generic;
using System.IO;
using Ink.Runtime;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueVariables
    {
        public Dictionary<string, Ink.Runtime.Object> Variables { get; private set; }

        public DialogueVariables(string globalsFilePath)
        {
            string inkFileContents = File.ReadAllText(globalsFilePath);
            Ink.Compiler compiler = new(inkFileContents);
            Story globalVariablesStory = compiler.Compile();

            Variables = new Dictionary<string, Ink.Runtime.Object>();
            foreach (string name in globalVariablesStory.variablesState)
            {
                Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(name);
                Variables.Add(name, value);
            }
        }

        public void StartListening(Story story)
        {
            VariablesToStory(story);
            story.variablesState.variableChangedEvent += VariableChanged;
        }

        public void StopListenig(Story story)
        {
            story.variablesState.variableChangedEvent -= VariableChanged;
        }

        private void VariableChanged(string name, Ink.Runtime.Object value)
        {
            if (Variables.ContainsKey(name))
            {
                Variables.Remove(name);
                Variables.Add(name, value);
            }
        }

        private void VariablesToStory(Story story)
        {
            foreach (KeyValuePair<string, Ink.Runtime.Object> variable in Variables)
            {
                story.variablesState.SetGlobal(variable.Key, variable.Value);
            }
        }
    }
}
