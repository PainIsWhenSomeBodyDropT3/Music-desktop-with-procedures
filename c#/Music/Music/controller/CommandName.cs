using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.controller
{
    public enum CommandName
    {

        CREATE_COMMENT,
        CREATE_GOOGLE_SONG,
        CREATE_MESSAGE,
        CREATE_MESSAGE_CONCLUSION_TIME,
        CREATE_PLAY_LIST,
        CREATE_PLAY_LIST_SONG,
        CREATE_SONG,
        CREATE_USER,
        CREATE_USER_DIALOG,
        CREATE_USER_DIALOGS,
        CREATE_USER_MESSAGE,

        READ_GOOGLE_SONG_BY_ID,
        READ_MESSAGE_BY_ID,
        READ_PLAY_LIST_BY_NAME,
        READ_PLAY_LIST_SONG_BY_SONG_AND_PLAY_LIST_IDS,
        READ_USER_BY_NAME,
        READ_USER_BY_ID,
        

        UPDATE_MESSAGE_CONCLUSION_TIME,
        UPDATE_PLAY_LIST,
        UPDATE_SONG,

        DELETE_COMMENT,
        DELETE_MESSAGE,
        DELETE_MESSAGE_CONCLUSION_TIME,
        DELETE_PLAY_LIST,
        DELETE_PLAY_LIST_SONG,
        DELETE_SONG,
        DELETE_USER,
        DELETE_USER_DIALOG,
        DELETE_USER_MESSAGE,

        ERROR,
        FIND_MESSAGE_CONCLUSION_BY_USERS_IDS,
        GET_ALL_COMMENTS_BY_SONG_ID,
        GET_ALL_PLAY_LISTS_BY_USER_ID,
        GET_ALL_REGISTERED_USERS,
        GET_ALL_SONG,
        GET_ALL_SONGS_BY_PLAY_LIST_ID,
        IS_USER_EXIST,
        IS_USER_REGISTERED,
        SEND_NOTIFICATION_FOR_USERS


    }
}
