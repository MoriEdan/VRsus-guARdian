﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour
{
    PlayerType type;


    public void Init(PlayerType bulletType, bool isLocalPlayer)
    {
        type = bulletType;

        if (isLocalPlayer)
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isServer)
            return;

        //Debug.Log(collision.gameObject);

        if (collision.gameObject.tag == tag || collision.gameObject.tag == "Platform")
        {
            Destroy(gameObject);
            return;
        }

        CameraAvatar avatar = collision.gameObject.GetComponent<CameraAvatar>();
        Combat combat = collision.gameObject.GetComponent<Combat>();

        //if (avatar && avatar.rootPlayer.GetComponent<PlayerInitializer>().PlayerType != type)
        //{
        //    avatar.rootPlayer.TakeDamage();
        //    Destroy(gameObject);
        //}
        //else if (combat && combat.GetComponent<PlayerInitializer>().PlayerType != type)
        //{
        //    combat.TakeDamage();
        //    Destroy(gameObject);
        //}
    }
}