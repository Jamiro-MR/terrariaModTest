using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace espadaMalota.NPCs
{
    [AutoloadHead]
    public class Inquisitor : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Inquisitor");
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 20;
            NPC.height = 20;
            NPC.aiStyle = 7;
            NPC.defense = 35;
            NPC.lifeMax = 300;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 0;
            NPCID.Sets.AttackFrameCount[NPC.type] = 1;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 30;
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            NPCID.Sets.HatOffsetY[NPC.type] = 4;
            AnimationType = 22;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            for (var i = 0; i < 255; i++)
            {
                Player player = Main.player[i];
                if(NPC.downedBoss1 == true){
                    return true;
                }
            }
            return false;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Margaret",
                "Maggy",
                "Magdalena"
            };
        }

        public override void SetChatButtons(ref string button, ref string button2){
            button = "Shop";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop){
            if (firstButton)
            {
                shop = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            //Wooden Arrow
            shop.item[nextSlot].SetDefaults(ItemID.Leather, false);
            shop.item[nextSlot].value = 600;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.WoodenBow, false);
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.TinBow, false);
            shop.item[nextSlot].value = 500;          
            nextSlot++;

            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(ItemID.PlatinumBow, false);
                nextSlot++;
            }
        }

        public override string GetChat()
        {
            NPC.FindFirstNPC(ModContent.NPCType<Inquisitor>());
            switch (Main.rand.Next(3))
            {
                case 0:
                    return "You did good hunting down that eye, you catched my attention.";
                case 1:
                    return "Test test test";
                case 2:
                    return "aaaaaaaaaaaa";
                default:
                    return "El pepe";
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 5f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 2;
            randExtraCooldown = 10;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.WoodenArrowFriendly;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 7f;
        }

        public override void OnKill()
        {
            Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.Ruby, 1, false, 0, false, false);
        }
    }
}