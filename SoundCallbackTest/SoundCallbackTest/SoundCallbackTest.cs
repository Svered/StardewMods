using System;
using Storm.ExternalEvent;
using Storm.StardewValley.Event;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace SoundCallbackTest
{
    [Mod]
    public class SoundCallbackTest : DiskResource
    {
        [Subscribe]
        public void PlaySoundCallback( PlaySoundEvent @event )
        {
            var sound = @event.SoundCue;
            var m = @event.Root.Content;
            if ( sound.Equals("dialogueCharacter") )
            {
                var menu = @event.Root.CurrentSpeaker;
                if ( menu != null )
                {
                    //Console.WriteLine("Sound Played: " + sound + " for " + menu.Name);
                    SoundEffect dialogue;
                    try
                    {
                        dialogue = m.Load<SoundEffect>("Voices\\" + menu.Name);
                    }
                    catch ( ContentLoadException )
                    {
                        return;
                    }
                    if ( dialogue != null )
                    {
                        @event.ReturnEarly = true;
                        dialogue.Play();
                    }
                }
            }
        }
    }
}
