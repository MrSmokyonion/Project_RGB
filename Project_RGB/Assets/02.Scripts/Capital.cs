using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capital : MonoBehaviour
{
    public int money = 0;
    public int crystal = 0;
    public int coupon = 0;

    public bool PlusMoney(int pMoney)
    {
        if (pMoney < 0)                             //뭘 입금하려는 거에여
        {
            return false;
        }
        else
        {
            money += pMoney;
            return true;
        }
    }

    public bool MinusMoney(int mMoney)
    {
        if (money < mMoney || mMoney < 0)           //돈이 없어영
        {
            return false;
        }
        else
        {
            money -= mMoney;
            return true;
        }
    }

    public bool PlusCrystal(int pCrystal)
    {
        if (pCrystal < 0)                             //뭘 입금하려는 거야
        {
            return false;
        }
        else
        {
            crystal += pCrystal;
            return true;
        }
    }

    public bool MinusCrystal(int mCrystal)
    {
        if (crystal < mCrystal || mCrystal < 0)           //스킬 파편이 없어영
        {
            return false;
        }
        else
        {
            crystal -= mCrystal;
            return true;
        }
    }

    public bool PlusCoupon(int pCoupon)
    {
        if (pCoupon < 0)                            //뭘 입금하려는 거에엵
        {
            return false;
        }
        else
        {
            coupon += pCoupon;
            return true;
        }
    }

    public bool MinusCoupon(int mCoupon)
    {
        if (coupon < mCoupon || mCoupon < 0)        //쿠폰이 없어영
        {
            return false;
        }
        else
        {
            coupon -= mCoupon;
            return true;
        }
    }

}
