import { observer } from 'mobx-react-lite';
import NavBarAccountDropDownLink from './NavBarAccountDropDownLink';

const NavBarAccountDropDown = () => {
  return (
    <div className="absolute right-0 w-full mt-2 origin-top-right rounded-md shadow-lg md:w-48">
      <div className="px-2 py-2 bg-white rounded-md shadow dark-mode:bg-gray-800">
        <NavBarAccountDropDownLink linkName={'Link #1'} linkPath={'/Link1'} />
        <NavBarAccountDropDownLink linkName={'Link #2'} linkPath={'/Link2'} />
        <NavBarAccountDropDownLink linkName={'Log Off'} linkPath={'/Signout'} />
      </div>
    </div>
  );
};

export default observer(NavBarAccountDropDown);
