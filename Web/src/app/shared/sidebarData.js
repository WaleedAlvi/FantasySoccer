import React from 'react';
import * as FaIcons from 'react-icons/fa';
import * as AiIcons from 'react-icons/ai';
import * as IoIcons from 'react-icons/io';

export const SideBarData = [
    {
        title: 'Home',
        path: '/',
        cName: 'nav-text',
        icon: <AiIcons.AiFillHome />,
    },
    {
        title: 'Contact',
        path: '/Contact',
        cName: 'nav-text',
        icon: <FaIcons.FaEnvelopeOpenText />,
    },
    {
        title: 'Support',
        path: '/Support',
        cName: 'nav-text',
        icon: <IoIcons.IoMdHelpCircle />,
    },
]