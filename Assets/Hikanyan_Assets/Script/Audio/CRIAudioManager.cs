using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;
public class CRIAudioManager : MonoBehaviour
{
    public static CRIAudioManager instance;
    [SerializeField] string _streamingAssetsPathACF = "Studying Unity";
    [SerializeField] string _cueSheetBGM = "CueSheet_BGM";//.acb
    //[SerializeField] string _cueSheetSE = "CueSheet_SE";//.acb

    [SerializeField, Range(0f, 1f)] float _bgmPlayVolume = default;
    [SerializeField, Range(0f, 1f)] float _sePlayVolume = default;

    bool _loopBGM;
    bool _loopSE;

    CriAtomSource _criAtomSourceBgm;
    CriAtomSource _criAtomSourceSe;

    private CriAtomExPlayback _criAtomExPlaybackBGM;
    CriAtomEx.CueInfo _cueInfo;

    bool isPlay = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            //acf�ݒ�
            string path = Common.streamingAssetsPath + $"/{_streamingAssetsPathACF}.acf";

            CriAtomEx.RegisterAcf(null, path);

            // CriAtom�쐬
            new GameObject().AddComponent<CriAtom>();

            // BGM acb�ǉ�
            CriAtom.AddCueSheet(_cueSheetBGM, $"{_cueSheetBGM}.acb", null, null);
            // SE acb�ǉ�
            //CriAtom.AddCueSheet(_cueSheetSE, $"{_cueSheetSE}.acb", null, null);


            //BGM�p��CriAtomSource���쐬
            _criAtomSourceBgm = gameObject.AddComponent<CriAtomSource>();
            _criAtomSourceBgm.cueSheet = _cueSheetBGM;
            //SE�p��CriAtomSource���쐬
            //_criAtomSourceSe = gameObject.AddComponent<CriAtomSource>();
            //_criAtomSourceSe.cueSheet = _cueSheetSE;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //�Q�[�����v���r���[�p�̃��x�����j�^�[�@�\��ǉ�
        CriAtom.SetBusAnalyzer(true);
    }

    public void CRIPlayBGM(int index)
    {
        bool startFlag = false;
        CriAtomSource.Status status = _criAtomSourceBgm.status;
        if ((status == CriAtomSource.Status.Stop) || (status == CriAtomSource.Status.PlayEnd))
        {
            this._criAtomExPlaybackBGM = _criAtomSourceBgm.Play(index);
            startFlag = true;
            isPlay = true;
        }
        if (startFlag == false)
        {
            int cur = this._criAtomExPlaybackBGM.GetCurrentBlockIndex();
            CriAtomExAcb acb = CriAtom.GetAcb("_cueSheetBGM");
            if (acb != null)
            {
                acb.GetCueInfo(index, out _cueInfo);

                cur++;
                if (_cueInfo.numBlocks > 0)
                {
                    _criAtomExPlaybackBGM.SetNextBlockIndex(cur % _cueInfo.numBlocks);
                }
            }
        }
    }
}
