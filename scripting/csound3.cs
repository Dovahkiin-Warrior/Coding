#include <sourcemod>
#define CHOICE1 "#choice1"
#define CHOICE2 "#choice2"
#define CHOICE3 "#choice3"
#define CHOICE3 "#choice3"
#define CHOICE4 "#choice4"
#define CHOICE5 "#choice5"
#define CHOICE6 "#choice6"
#define CHOICE7 "#choice7"
#define CHOICE8 "#choice8"
#define CHOICE9 "#choice9"

public Plugin:myinfo =
{
	name = "Selena's Sounds",
	author = "DovahkiinYT",
	description = "Selena's Playsound Command",
	version = "1.0",
	url = "https://github.com/Dovahkiin-Warrior/ , http://sourcemm.net"
};
public OnPluginStart()
{
	RegConsoleCmd("sm_selena", Command_Sound2, "Sound Menu for Selena's Content");
	LoadTranslations("selena.phrases");
}
public MenuHandler1(Handle:menu, MenuAction:action, client, param2)
{
	switch(action)
	{
		case MenuAction_Start:
		{
			//What happens when the menu starts
		}
		case MenuAction_Display:
		{
	 		decl String:buffer[255];
			Format(buffer, sizeof(buffer), "%T", "Vote Nextmap", client);
 
			new Handle:panel = Handle:param2;
			SetPanelTitle(panel, buffer);
			PrintToServer("Client %d was sent menu with panel %x", client, param2);
		}
 
		case MenuAction_Select:
		{
			decl String:info[32];
			GetMenuItem(menu, param2, info, sizeof(info));
			if (StrEqual(info, CHOICE1))
			{
				FakeClientCommand(client,"sm_play @all selena/aprage.mp3");
			}
			if (StrEqual(info, CHOICE2))
			{
				FakeClientCommand(client,"sm_play @all selena/blitz1.mp3");
			}
			if (StrEqual(info, CHOICE3))
			{
				FakeClientCommand(client,"sm_play @all selena/blitz2.mp3");
			}
			if (StrEqual(info, CHOICE4))
			{
				FakeClientCommand(client,"sm_play @all selena/lets_go.mp3");
			}
			if (StrEqual(info, CHOICE5))
			{
				FakeClientCommand(client,"sm_play @all selena/mineralwater.mp3");
			}
			if (StrEqual(info,CHOICE6))
			{
				FakeClientCommand(client,"sm_play @all selena/one_on_one.mp3");
			}
			if (StrEqual(info,CHOICE7))
			{
				FakeClientCommand(client,"sm_play @all dovahyt/spy.mp3");
			}
			if (StrEqual(info,CHOICE8))
			{
				FakeClientCommand(client,"sm_play @all selena/the_best.mp3");
			}
			if (StrEqual(info,CHOICE9))
			{
				FakeClientCommand(client,"sm_selena2");
			}
	}
 
		case MenuAction_Cancel:
		{
			PrintToChatAll("Client %d's menu was cancelled for reason %d", client, param2);
		}
 
		case MenuAction_End:
		{
			CloseHandle(menu);
		}
 
		case MenuAction_DrawItem:
		{
			new style;
			decl String:info[32];
			GetMenuItem(menu, param2, info, sizeof(info), style);
			if (StrEqual(info, CHOICE3))
			{
				return style;
			}
			else
			{
				return style;
			}
		}
 
		case MenuAction_DisplayItem:
		{
			decl String:info[32];
			GetMenuItem(menu, param2, info, sizeof(info));
 
			decl String:display[64];
			if (StrEqual(info, CHOICE3))
			{
				Format(display, sizeof(display), "%T", "Choice 3", client);
				return RedrawMenuItem(display);
			}
		}
	}
 
	return 0;
}
 
public Action:Command_Sound2(client, args)
{
	new Handle:menu = CreateMenu(MenuHandler1, MENU_ACTIONS_ALL);
	SetMenuTitle(menu, "%T", "Menu Title", LANG_SERVER);
	AddMenuItem(menu, CHOICE1, "Ass Pancakes Rage");
	AddMenuItem(menu, CHOICE2, "Blitzkrieg 1");
	AddMenuItem(menu, CHOICE3, "Blitzkrieg 2");
	AddMenuItem(menu, CHOICE4, "Let's Go Ya Little Bitch!");
	AddMenuItem(menu, CHOICE5, "Mineral Water!");
	AddMenuItem(menu, CHOICE6, "One on One!");
	AddMenuItem(menu, CHOICE7, "Meep Meep!");
	AddMenuItem(menu, CHOICE8, "I'm the Best!");
	AddMenuItem(menu, CHOICE9, "More");
	SetMenuExitButton(menu, true);
	DisplayMenu(menu, client, 60);
 
	return Plugin_Handled;
}